using ME.Domain.Interface;
using System.Data;

namespace ME.Infrasctructure.Common
{
    public abstract class RepositoryBase
    {
        public IResponse _response;
        protected IDbTransaction Transaction;
        protected IDbConnection Connection { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="response"></param>
        /// <param name="connection"></param>
        protected RepositoryBase(IResponse response,
            IDbConnection connection)
        {
            _response = response;
            Connection = connection;
        }

        public virtual string QuerySelect { get; set; }
        public virtual string QuerySelectAll { get; set; }
        public virtual string QueryInsert { get; set; }
        public virtual string QueryUpdate { get; set; }
        public virtual string QueryDelete { get; set; }


    }
}
