using System;
using System.Collections.Generic;
using System.Text;
using Application.DTOs.Persona;
using Application.Interfaces.Persona;
namespace Application.Commands.Persona
{
    public class CreatePersonaCommand
    {
        private readonly IPersonaRepository _personaRepository;
        public CreatePersonaCommand(IPersonaRepository personaRepository)
        {
            _personaRepository = personaRepository;
        }
        
        public async Task<int> Execute(CreatePersonaDTO createPersonaDTO)
        {
            return await _personaRepository.CreatePersona(createPersonaDTO);
        }
    }
}
