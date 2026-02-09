using Microsoft.Data.SqlClient;
using System.Data;
using Api_GeneradorPDFs.infrastructure.Persistence.Connection;
using Api_GeneradorPDFs.application.interfaces;
using Application.DTOs.Persona;
using Dapper;

namespace Api_GeneradorPDFs.infrastructure.Persistence.Repository.Persona
{
    public class PersonaRepository
    {

        private readonly SqlConnectionFactorycs _connectionFactory;

        public PersonaRepository (SqlConnectionFactorycs sqlConnectionFactorycs)
        {
            
            sqlConnectionFactorycs = _connectionFactory;
        }

        public async Task<IEnumerable<PersonaDTO>> GetAllPersona()
        {
            try
            {
                using var connection = _connectionFactory.CreateConnection();

                return await connection.QueryAsync<PersonaDTO>(
                    "sp_GetAllPersona", commandType: CommandType.StoredProcedure
                );
            }catch(SqlException ex)
            {
                
                throw new Exception("Error al obtener las personas: " + ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                // Error de conexión
                throw new ApplicationException("No se pudo abrir la conexión", ex);
            }
        }






    }
}
