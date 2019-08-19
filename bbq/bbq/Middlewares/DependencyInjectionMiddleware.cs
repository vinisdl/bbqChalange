using bbq.BusinessCore;
using bbq.BusinessCore.Interfaces;
using bbq.Domain.Entities;
using bbq.Repository.Interfaces;
using bbq.Repository.Layers;
using bbq.Services.Interfaces;
using bbq.Services.Layers;
using Microsoft.Extensions.DependencyInjection;

namespace bbq.Application.Middlewares
{
    /// <summary>
    /// Classe de inserção de injeção de dependência
    /// </summary>
    public static class DependencyInjectionMiddleware
    {
        /// <summary>
        /// Método de inserção de injeção de dependência
        /// </summary>
        /// <param name="services">serviços</param>
        public static void AddDependencyInjection(this IServiceCollection services)
        {                        
            services.AddTransient<IUserRepository, UserMemoryRepository>();            
            services.AddTransient<IAuthBusinessCore, AuthBusinessCore>();
            services.AddTransient<ITokenBusinessCore, TokenBusinessCore>();
            services.AddTransient<IUserServices, UserServices>();
        }
    }
}