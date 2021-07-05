using ME.Domain.Model;

namespace ME.Domain.Interface
{
    public interface IStatusPedidoService
    {
        RetornoMudancaStatusPedido DefinirStatusPedido(RetornoMudancaStatusPedido retornoPedido, ParametroMudancaStatusPedido parametroMudancaStatusPedido, ParametroMudancaStatusPedido calculoPersistido);
    }
}
