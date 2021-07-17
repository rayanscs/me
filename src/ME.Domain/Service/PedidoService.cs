using ME.Domain.Interface;
using ME.Domain;
using ME.Domain.Model;
using ME.Domain.Model.Http;
using ME.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ME.Domain.Service
{
    public class PedidoService : IPedidoService
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IValidacaoService _validacaoService;
        private readonly IStatusPedidoService _statusPedidoService;
        private readonly IUnitOfWork _uow;

        public PedidoService(IPedidoRepository pedidoRepository,
                             IValidacaoService validacaoService,
                             IStatusPedidoService statusPedidoService,
                             IUnitOfWork uow
            )
        {
            _pedidoRepository = pedidoRepository;
            _validacaoService = validacaoService;
            _statusPedidoService = statusPedidoService;
            _uow = uow;
        }

        public IResponse StatusPedido(ParametroMudancaStatusPedido parametroMudancaStatusPedido)
        {
            var response = new Response();
            var retornoPedido = new RetornoMudancaStatusPedido();
            retornoPedido.Pedido = parametroMudancaStatusPedido.PedidoId.ToString();

            var validacaoId = _validacaoService.ValidaSomenteNumeros(parametroMudancaStatusPedido.PedidoId.ToString());

            #region PedidoId inválido
            if (!validacaoId)
            {
                retornoPedido.Status.Add(EnumStatusPedido.Invalido.GetDescription());
                response.SetData(retornoPedido);
                return response;
            }
            #endregion

            #region Obter informações pedido
            var result = _uow.PedidoRepository.ObterPedido(Convert.ToInt32(parametroMudancaStatusPedido.PedidoId));
            if (!result.Sucesso)
            {
                response.AddNotifications(result.Notifications);
                return response;
            }

            var itensPedido = (List<Item>)result.Data;
            #endregion

            retornoPedido = DefineResultadoMudancaStatus(parametroMudancaStatusPedido, retornoPedido, itensPedido);
            response.SetData(retornoPedido);
            return response;
        }

        public IResponse ObterPedido(int pedidoId)
        {
            var result = _uow.PedidoRepository.ObterPedido(pedidoId);
            return result;
        }

        public RetornoMudancaStatusPedido DefineResultadoMudancaStatus(ParametroMudancaStatusPedido parametroMudancaStatusPedido, 
                                                                       RetornoMudancaStatusPedido retornoPedido, 
                                                                       List<Item> itensPedido)
        {
            if (!itensPedido.Any())
            {
                retornoPedido.Status.Add(EnumStatusPedido.Invalido.GetDescription());
                return retornoPedido;
            }
            var statusRecebido = EnumExtensions.GetValueFromDescription<EnumStatusPedido>(parametroMudancaStatusPedido.Status);

            switch (statusRecebido)
            {
                case EnumStatusPedido.Aprovado:

                    var calculoPersistido = CalcularRegistroPersistido(itensPedido);
                    retornoPedido = _statusPedidoService.DefinirStatusPedido(retornoPedido, parametroMudancaStatusPedido, calculoPersistido);
                    break;
                case EnumStatusPedido.Reprovado:
                    retornoPedido.Status.Add(EnumStatusPedido.Reprovado.GetDescription());
                break;
                default:
                    break;
            }

            return retornoPedido;
        }

        public ParametroMudancaStatusPedido CalcularRegistroPersistido(List<Item> itensPedido)
        {
            var pedidoCalculado = new ParametroMudancaStatusPedido
            {
                PedidoId = itensPedido.FirstOrDefault().PedidoId.ToString(),
                ItensAprovados = itensPedido.Sum(i => i.Quantidade),
                ValorAprovado = DescobreValorArprovadoPedido(itensPedido)
            };

            return pedidoCalculado;
        }

        public decimal DescobreValorArprovadoPedido(List<Item> itensPedido)
        {
            var todosValores = new List<decimal>();

            foreach (var item in itensPedido)
            {
                var valor = item.PrecoUnitario * item.Quantidade;
                todosValores.Add(valor);
            }

            return todosValores.Sum();
        }




    }
}
