using ME.Domain.Interface;
using ME.Infrasctructure.Repository;
using Microsoft.Extensions.Options;
using System.Data;

namespace ME.Infrasctructure.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private IDbConnection DbConnection { get; set; }
        public IDbTransaction DbTransaction { get; set; }

        private readonly ConnectionSettings _dbConfig;

        public UnitOfWork(IOptions<ConnectionSettings> configuration)
        {
            _dbConfig = configuration.Value;
        }

        public IPedidoRepository PedidoRepository
        {
            get
            {
                DbConnection = _dbConfig.SqlServerConnection;
                return new PedidoRepository(_dbConfig.SqlServerConnection);
            }
        }

        public void BeginTransaction()
        {
            if (this.DbConnection.State == ConnectionState.Closed)
                this.DbConnection.Open();

            DbTransaction = this.DbConnection.BeginTransaction();
        }

        public void Rollback()
        {
            if (DbTransaction != null)
                DbTransaction.Rollback();
        }

        public void Commit()
        {
            try
            {
                if (DbTransaction != null)
                    DbTransaction.Commit();
            }
            catch
            {
                if (DbTransaction != null)
                    DbTransaction.Rollback();
                throw;
            }
            finally
            {
                if (DbTransaction != null)
                    DbTransaction.Dispose();
            }
        }
    }
}
