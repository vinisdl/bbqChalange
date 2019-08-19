using bbq.Application.Filters;
using bbq.Application.Operation_Filter;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using Swashbuckle.AspNetCore.Swagger;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;

namespace bbq.Application.Middlewares
{
    [ExcludeFromCodeCoverage]
    public static class SwaggerMiddlerware
    {
        public static void AddSwaggerService(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new Info
                    {
                        Title = "bbq",
                        Version = "v1",
                        Description = "BBQ API",
                        Contact = new Contact
                        {
                            Name = "Marco Vinicius Soares Dalalba",
                            Url = "www.marcodalalba.com"
                        }
                    });

                var caminhoAplicacao =
                    PlatformServices.Default.Application.ApplicationBasePath;
                var caminhoXmlDoc =
                    Path.Combine(caminhoAplicacao, $"bbq.Application.xml");

                c.IncludeXmlComments(caminhoXmlDoc);

                c.OperationFilter<AddRequiredHeaderParameter>();
            });
        }

        public static void AddSwaggerApp(this IApplicationBuilder app, string routePrefix)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json",
                    "BBQ API");

                c.RoutePrefix = routePrefix;
            });
        }
    }
}