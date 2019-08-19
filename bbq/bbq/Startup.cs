using bbq.Application.Middlewares;
using bbq.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace bbq.Application
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            LoadDbConfig(services);

            LoadCustomMiddlers(services, Configuration);

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                            .AddJsonOptions(options =>
                            {
                                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                                options.SerializerSettings.DefaultValueHandling = DefaultValueHandling.Ignore;
                            }); ;
        }

        private static void LoadDbConfig(IServiceCollection services)
        {
            services.AddDbContext<BBQContext>(options =>
                        options.UseInMemoryDatabase(databaseName: "bbq"));
        }

        private static void LoadCustomMiddlers(IServiceCollection services, IConfiguration configuration)
        {
            services.AddJwtMiddleware(configuration);
            services.AddLoggerMiddleware();
            services.AddDependencyInjection();
            services.AddSwaggerService();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, BBQContext bBQContext)
        {
            if (env.IsDevelopment())
            {
                SeedData.Run(bBQContext);
                app.UseDeveloperExceptionPage();
            }

            app.AddSwaggerApp("docs");
            app.UseMvc();
        }
    }
}