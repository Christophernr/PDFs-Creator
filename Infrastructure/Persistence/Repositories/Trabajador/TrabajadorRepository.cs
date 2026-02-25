using System;
using System.Collections.Generic;
using System.Text;
using Application.DTOs.Trabajador;
using Application.Interfaces.Trabajador;
using Api_GeneradorPDFs.application.interfaces;
using Dapper;
using System.Data; 
using Microsoft.Data.SqlClient;
namespace Infrastructure.Persistence.Repositories.Trabajador
{
    public class TrabajadorRepository : ITrabajadorRepository
    {
        private readonly IConnectionFactory _connectionFactory;

        public TrabajadorRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<TrabajadorDTO> GetTrabajadorById(int idTrabajador)
        {
            try
            {
                using var connection = _connectionFactory.CreateConnection();
                return await connection.QueryFirstOrDefaultAsync<TrabajadorDTO>(
                    "sp_BuscarTrabajador", new { idTrabajador }, commandType: CommandType.StoredProcedure
                );
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al obtener el trabajador: " + ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                // Error de conexión
                throw new ApplicationException("No se pudo abrir la conexión", ex);
            }
        }

        //public async Task<IEnumerable<TrabajadorDTO>> GetAllTrabajadores()
        //{
        //    try
        //    {
        //        using var connection = _connectionFactory.CreateConnection();
        //        return await connection.QueryAsync<TrabajadorDTO>(
        //            "sp_GetAllTrabajadores", commandType: CommandType.StoredProcedure
        //        );
        //    }
        //    catch (SqlException ex)
        //    {
        //        throw new Exception("Error al obtener los trabajadores: " + ex.Message);
        //    }
        //    catch (InvalidOperationException ex)
        //    {
        //        // Error de conexión
        //        throw new ApplicationException("No se pudo abrir la conexión", ex);
        //    }
        //}

        public async Task EditarTrabajador(EditarTrabajadorDTO editTrabajadorDTO)
        {
            try
            {
                using var connection = _connectionFactory.CreateConnection();
                await connection.ExecuteAsync(
                    "sp_EditarTrabajador",
                    new
                    {
                        idTrabajador = editTrabajadorDTO.idTrabajador,
                        Puesto = editTrabajadorDTO.puesto,
                        departamentoId = editTrabajadorDTO.departamentoId
                    },
                    commandType: CommandType.StoredProcedure
                );
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al editar el trabajador: " + ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                // Error de conexión
                throw new ApplicationException("No se pudo abrir la conexión", ex);
            }
        }

        public async Task EliminarTrabajador(int idTrabajador)
        {
            try
            {
                using var connection = _connectionFactory.CreateConnection();
                await connection.ExecuteAsync(
                    "sp_EliminarTrabajador",
                    new { idTrabajador },
                    commandType: CommandType.StoredProcedure
                );
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al eliminar el trabajador: " + ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                // Error de conexión
                throw new ApplicationException("No se pudo abrir la conexión", ex);
            }
        }
    }
}
