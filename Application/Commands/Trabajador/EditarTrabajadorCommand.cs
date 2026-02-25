using System;
using System.Collections.Generic;
using System.Text;
using Application.DTOs.Trabajador;
using Application.Interfaces.Trabajador;
namespace Application.Commands.Trabajador
{
    public class EditarTrabajadorCommand
    {
        private readonly ITrabajadorRepository _trabajadorRepository;
        public EditarTrabajadorCommand(ITrabajadorRepository trabajadorRepository)
        {
            _trabajadorRepository = trabajadorRepository;
        }
        public async Task Execute(EditarTrabajadorDTO editTrabajadorDTO)
        {
            await _trabajadorRepository.EditarTrabajador(editTrabajadorDTO);
        }
    }
}
