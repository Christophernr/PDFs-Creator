using System;
using System.Collections.Generic;
using System.Text;
using Application.DTOs.Persona;
using Application.Interfaces.Persona;
namespace Application.Commands.Persona
{
    public class EditarPersonaCommand
    {
        private readonly IPersonaRepository _personaRepository;

        public EditarPersonaCommand(IPersonaRepository personaRepository)
        {
            _personaRepository = personaRepository;
        }

        public async Task Execute(EditarPersonaDTO editPersonaDTO)
        {
            await _personaRepository.EditarPersona(editPersonaDTO);
        }
    }
}
