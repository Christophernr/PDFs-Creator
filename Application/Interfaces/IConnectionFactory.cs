using System.Data;

namespace Api_GeneradorPDFs.application.interfaces
{
    public interface IConnectionFactory
    {
        IDbConnection CreateConnection();
    }
}
