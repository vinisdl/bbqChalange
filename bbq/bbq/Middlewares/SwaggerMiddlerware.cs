﻿using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using Swashbuckle.AspNetCore.Swagger;
using System.Diagnostics.CodeAnalysis;
using System.IO;

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
                        Description = "Auhorization Jwt Api",
                        Contact = new Contact
                        {
                            Name = "Alexandre Brandão Lustosa",
                            Url = "https://github.com/alexandrebl/bbq"
                        }
                    });

                var caminhoAplicacao =
                    PlatformServices.Default.Application.ApplicationBasePath;
                var caminhoXmlDoc =
                    Path.Combine(caminhoAplicacao, $"bbq.Application.xml");

                c.IncludeXmlComments(caminhoXmlDoc);
            });
        }

        public static void AddSwaggerApp(this IApplicationBuilder app, string routePrefix)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json",
                    "Auhorization Jwt Api");

                c.RoutePrefix = routePrefix;
            });
        }
    }
}