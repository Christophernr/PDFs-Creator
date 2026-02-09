using System.Data;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Api_GeneradorPDFs.infrastructure.Persistence.Connection
{
    public class SqlConnectionFactorycs
    {
        private readonly string _connectionString;

        public SqlConnectionFactorycs(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public IDbConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }

    }
}
