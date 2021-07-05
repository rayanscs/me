using System.Data;
using System.Data.SqlClient;

namespace ME.Infrasctructure.UoW
{
    public class ConnectionSettings
    {
        public IDbConnection SqlServerConnection => new SqlConnection(SqlServerConnectionString);
        public string SqlServerConnectionString { get; set; }
    }
}
