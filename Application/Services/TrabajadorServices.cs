using System;
using System.Collections.Generic;
using System.Text;
using Application.DTOs.Trabajador;
using Application.Interfaces.Trabajador;
using Application.Commands.Trabajador;
using Application.Queries.Trabajador;
namespace Application.Services
{
    public class TrabajadorServices
    {
        private readonly GetTrabajadorById _getTrabajadorById;
        private readonly EditarTrabajadorCommand editarTrabajadorCommand;
        private readonly EliminarTrabajadorCommand eliminarTrabajadorCommand;
        public Task<TrabajadorDTO> GetTrabajadorById(int idTrabajador)
        {
            return _getTrabajadorById.Execute(idTrabajador);
        }

        public Task EditarTrabajador(EditarTrabajadorDTO editarTrabajadorDTO)
        {
            return editarTrabajadorCommand.Execute(editarTrabajadorDTO);
        }

        public Task EliminarTrabajador(int idTrabajador)
        {
            return eliminarTrabajadorCommand.Execute(idTrabajador);
        }
    }
}
