using System;
using System.Collections.Generic;
using System.Text;
using Application.DTOs.Trabajador;
using Application.Interfaces.Trabajador;
namespace Application.Interfaces.Trabajador
{
    public interface ITrabajadorRepository
    {

        Task<TrabajadorDTO> GetTrabajadorById(int idTrabajador);
        // Task<IEnumerable<TrabajadorDTO>> GetAllTrabajadores();
        Task EditarTrabajador(EditarTrabajadorDTO editarTrabajadorDTO);
        Task EliminarTrabajador(int idTrabajador);
    }
}
