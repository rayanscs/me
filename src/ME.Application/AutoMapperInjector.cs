using AutoMapper;
using ME.Application.MVVM;
using ME.Domain.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace ME.Application
{
    public static class AutoMapperInjector
    {
        public static IServiceCollection AutoMapperRegister(this IServiceCollection services, IConfiguration config)
        {
            var configMapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Item, ItemViewModel>().ForMember(dest => dest.Qtd, opt => opt.MapFrom(src => src.Quantidade));
                cfg.CreateMap<List<ItemViewModel>, PedidoViewModel>().ForMember(dest => dest.Itens, member => member.MapFrom(src => src));
                cfg.CreateMap<ParametroMudancaStatusPedidoViewModel, ParametroMudancaStatusPedido>();
                cfg.CreateMap<ParametroMudancaStatusPedidoViewModel, ParametroMudancaStatusPedido>().ForMember(dest => dest.PedidoId, member => member.MapFrom(src => src.Pedido));
                cfg.CreateMap<RetornoMudancaStatusPedido, RetornoMudancaStatusPedidoViewModel>();

            });

            IMapper mapper = configMapper.CreateMapper();
            services.AddSingleton(mapper);

            return services;
        }


    }
}
