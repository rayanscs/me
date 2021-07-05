using ME.Application.MVVM;
using ME.Domain.Interface;

namespace ME.Application.Interface
{
    public interface IPedidoAppService
    {
        IResponse ObterPedido(string pedidoId);
        IResponse StatusPedido(ParametroMudancaStatusPedidoViewModel parametroMudancaStatusPedidoViewModel);
    }
}
