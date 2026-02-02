using Microsoft.Data.SqlClient;
using System.Data;

namespace Api_GeneradorPDFs.infrastructure.Persistence.Repository.Persona
{
    public class PersonaRepository
    {
        private readonly string _connectionString;

        public PersonaRepository (IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }




    }
}
