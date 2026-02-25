using System;
using System.Collections.Generic;
using System.Text;
using Application.DTOs.Trabajador;
using Application.Interfaces.Trabajador;
namespace Application.Commands.Trabajador
{
    public class EliminarTrabajadorCommand
    {
        private readonly ITrabajadorRepository _trabajadorRepository;
        public EliminarTrabajadorCommand(ITrabajadorRepository trabajadorRepository)
        {
            _trabajadorRepository = trabajadorRepository;
        }
        public async Task Execute(int idTrabajador)
        {
            await _trabajadorRepository.EliminarTrabajador(idTrabajador);
        }
    }
}
