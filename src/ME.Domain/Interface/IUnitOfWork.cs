using System.Data;

namespace ME.Domain.Interface
{
    public interface IUnitOfWork
    {
        IPedidoRepository PedidoRepository { get; }

        IDbTransaction DbTransaction { get; set; }

        void Commit();
        void BeginTransaction();
        void Rollback();

    }

}
