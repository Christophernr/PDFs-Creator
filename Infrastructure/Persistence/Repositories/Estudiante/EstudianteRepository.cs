using System;
using System.Collections.Generic;
using System.Text;
using Application.DTOs.Estudiante;
using Application.Interfaces.Estudiante;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;
using Api_GeneradorPDFs.application.interfaces;


namespace Infrastructure.Persistence.Repositories.Estudiante
{
    public class EstudianteRepository : IEstudianteRepository
    {
        private readonly IConnectionFactory _connectionFactory;

        public EstudianteRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<EstudianteDTO> GetEstudianteById(int idEstudiante)
        {
            try
            {
                using var connection = _connectionFactory.CreateConnection();
                return await connection.QueryFirstOrDefaultAsync<EstudianteDTO>(
                    "sp_BuscarEstudiante", new { idEstudiante }, commandType: CommandType.StoredProcedure
                );
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al obtener el estudiante: " + ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                // Error de conexión
                throw new ApplicationException("No se pudo abrir la conexión", ex);
            }
        }
        // public async Task<IEnumerable<EstudianteDTO>> GetAllEstudiantes()
        //{
        //    try
        //    {
        //        using var connection = _connectionFactory.CreateConnection();
        //        return await connection.QueryAsync<EstudianteDTO>(
        //            "sp_GetAllEstudiantes", commandType: CommandType.StoredProcedure
        //        );
        //    }
        //    catch (SqlException ex)
        //    {
        //        throw new Exception("Error al obtener los estudiantes: " + ex.Message);
        //    }
        //    catch (InvalidOperationException ex)
        //    {
        //        // Error de conexión
        //        throw new ApplicationException("No se pudo abrir la conexión", ex);
        //    }
        //}

        public async Task EditarEstudiante(EditarEstudianteDTO editarEstudianteDTO)
        {
            try
            {
                using var connection = _connectionFactory.CreateConnection();
                await connection.ExecuteAsync(
                    "sp_EditarEstudiante",
                    new
                    {

                        idEstudiante = editarEstudianteDTO.Id,
                        SeccionId = editarEstudianteDTO.seccionID,
                        nivel = editarEstudianteDTO.nivel
                    },
                    commandType: CommandType.StoredProcedure
                );
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al editar el estudiante: " + ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                // Error de conexión
                throw new ApplicationException("No se pudo abrir la conexión", ex);
            }
        }

        public async Task EliminarEstudiante(int idEstudiante)
        {
            try
            {
                using var connection = _connectionFactory.CreateConnection();
                await connection.ExecuteAsync(
                    "sp_EliminarEstudiante",
                    new { idEstudiante },
                    commandType: CommandType.StoredProcedure
                );
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al eliminar el estudiante: " + ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                // Error de conexión
                throw new ApplicationException("No se pudo abrir la conexión", ex);
            }

        }
    }
}