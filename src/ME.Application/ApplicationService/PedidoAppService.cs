using AutoMapper;
using ME.Application.Interface;
using ME.Application.MVVM;
using ME.Domain.Interface;
using ME.Domain.Model;
using ME.Domain.Model.Http;
using System;
using System.Collections.Generic;

namespace ME.Application.ApplicationService
{
    public class PedidoAppService : IPedidoAppService
    {
        private readonly IPedidoService _pedidoService;
        private IMapper _mapper;

        public PedidoAppService(IPedidoService pedidoService, IMapper mapper)
        {
            _pedidoService = pedidoService;
            _mapper = mapper;
        }

        public IResponse StatusPedido(ParametroMudancaStatusPedidoViewModel parametroMudancaStatusPedidoViewModel)
        {
            var responseViewModel = new Response();

            var parametroMudancaStatusPedido = _mapper.Map<ParametroMudancaStatusPedido>(parametroMudancaStatusPedidoViewModel);

            var response = _pedidoService.StatusPedido(parametroMudancaStatusPedido);
            if (!response.Sucesso)
            {
                responseViewModel.AddNotifications(response.Notifications);
                return responseViewModel;
            }

            var model = (RetornoMudancaStatusPedido)response.Data;
            var viewModel = _mapper.Map<RetornoMudancaStatusPedidoViewModel>(model);
            return responseViewModel.SetData(viewModel);
        }

        public IResponse ObterPedido(string pedidoId)
        {
            var responseViewModel = new Response();

            var response = _pedidoService.ObterPedido(Convert.ToInt32(pedidoId));
            if (!response.Sucesso)
            {
                responseViewModel.AddNotifications(response.Notifications);
                return responseViewModel;
            }

            var model = (List<Item>)response.Data;

            var itemVM = _mapper.Map<List<ItemViewModel>>(model);
            var viewModel = _mapper.Map<List<ItemViewModel>, PedidoViewModel>(itemVM);
            viewModel.Pedido = pedidoId;
            return responseViewModel.SetData(viewModel);
        }
    }
}
