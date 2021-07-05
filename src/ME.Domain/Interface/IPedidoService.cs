using ME.Domain.Model;
using System.Collections.Generic;

namespace ME.Domain.Interface
{
    public interface IPedidoService
    {
        IResponse ObterPedido(int pedidoId);
        IResponse StatusPedido(ParametroMudancaStatusPedido parametroMudancaStatusPedido);
        RetornoMudancaStatusPedido DefineResultadoMudancaStatus(ParametroMudancaStatusPedido parametroMudancaStatusPedido, RetornoMudancaStatusPedido retornoPedido, List<Item> itensPedido);
        ParametroMudancaStatusPedido CalcularRegistroPersistido(List<Item> itensPedido);
        decimal DescobreValorArprovadoPedido(List<Item> itensPedido);
    }




}
