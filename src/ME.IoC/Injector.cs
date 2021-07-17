using ME.Application.ApplicationService;
using ME.Application.Interface;
using ME.Domain.Interface;
using ME.Domain.Model.Http;
using ME.Domain.Service;
using ME.Infrasctructure.Repository;
using ME.Infrasctructure.UoW;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ME.IoC
{
    public static class Injector
    {
        public static IServiceCollection Register(this IServiceCollection services, IConfiguration config)
        {
            services.AddTransient<IResponse, Response>();
            services.AddScoped<IValidacaoService, ValidacaoService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IPedidoRepository, PedidoRepository>();
            services.AddScoped<IStatusPedidoService, StatusPedidoService>();
            services.AddScoped<IPedidoService, PedidoService>();
            services.AddScoped<IPedidoAppService, PedidoAppService>();

            return services;
        }
    }

    
}
