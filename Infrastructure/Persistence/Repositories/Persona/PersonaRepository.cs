using Api_GeneradorPDFs.application.interfaces;
using Application.DTOs.Persona;
using Application.Interfaces.Persona;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Api_GeneradorPDFs.infrastructure.Persistence.Repository.Persona
{
    public class PersonaRepository : IPersonaRepository
    {

        private readonly IConnectionFactory _connectionFactory;

        public PersonaRepository(IConnectionFactory connectionFactory)
        {

            _connectionFactory = connectionFactory;
        }

        public async Task<IEnumerable<PersonaDTO>> GetAllPersona()
        {
            try
            {
                using var connection = _connectionFactory.CreateConnection();

                return await connection.QueryAsync<PersonaDTO>(
                    "sp_GetAllPersona", commandType: CommandType.StoredProcedure
                );
            }
            catch (SqlException ex)
            {

                throw new Exception("Error al obtener las personas: " + ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                // Error de conexión
                throw new ApplicationException("No se pudo abrir la conexión", ex);
            }
        }

        public async Task<PersonaDTO> GetPersonaById(int idPersona)
        {
            try
            {
                using var connection = _connectionFactory.CreateConnection();

                return await connection.QueryFirstOrDefaultAsync<PersonaDTO>(
                    "sp_BuscarPersonaId", new { idPersona }, commandType: CommandType.StoredProcedure
                );
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al obtener la persona: " + ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                // Error de conexión
                throw new ApplicationException("No se pudo abrir la conexión", ex);
            }

        }

        public async Task<int> CreatePersona(CreatePersonaDTO persona)
        {
            try
            {
                using var connection = _connectionFactory.CreateConnection();
                await connection.QuerySingleAsync<int>(
                    "sp_InsertPersona",
                    new
                    {
                        nombre = persona.nombre,
                        apellido = persona.apellido,
                        fechaIngreso = DateTime.Now,
                        telefono = persona.telefono,
                        direccion = persona.direccion,
                        tipo = persona.tipo,

                        SeccionId = persona.SeccionId,
                        nivel = persona.Nivel,
                        Puesto = persona.Puesto,
                        departamentoId = persona.DepartamentoId
                    },
                    commandType: CommandType.StoredProcedure
                );

                return await connection.QuerySingleAsync<int>("SELECT SCOPE_IDENTITY()"); // Obtener el ID generado
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al crear la persona: " + ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                // Error de conexión
                throw new ApplicationException("No se pudo abrir la conexión", ex);
            }
        }

        public async Task EditarPersona(EditarPersonaDTO editarPersonaDTO)
        {
            try
            {
                using var connection = _connectionFactory.CreateConnection();
                await connection.ExecuteAsync(
                    "sp_EditarPersona",
                    new
                    {
                        idPersona = editarPersonaDTO.idPersona,
                        nombre = editarPersonaDTO.nombre,
                        apellido = editarPersonaDTO.apellido,
                        telefono = editarPersonaDTO.telefono,
                        direccion = editarPersonaDTO.direccion,
                        tipo = editarPersonaDTO.tipo,
                        fechaSalida = editarPersonaDTO.fechaSalida,

                        SeccionId = editarPersonaDTO.SeccionId,
                        nivel = editarPersonaDTO.Nivel,
                        Puesto = editarPersonaDTO.Puesto,
                        departamentoId = editarPersonaDTO.DepartamentoId
                    },
                    commandType: CommandType.StoredProcedure
                );
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al editar la persona: " + ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                // Error de conexión
                throw new ApplicationException("No se pudo abrir la conexión", ex);
            }
        }

        public async Task EliminarPersona(int idPersona)
        {
            try
            {
                using var connection = _connectionFactory.CreateConnection();
                await connection.ExecuteAsync(
                    "sp_DeletePersona",
                    new { idPersona },
                    commandType: CommandType.StoredProcedure
                );
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al eliminar la persona: " + ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                // Error de conexión
                throw new ApplicationException("No se pudo abrir la conexión", ex);
            }
        }
    }
}