namespace ME.Domain.Interface
{
    public interface IPedidoRepository
    {
        IResponse ObterPedido(int pedidoId);
        IResponse ObterStatusPedido();
    }
}
