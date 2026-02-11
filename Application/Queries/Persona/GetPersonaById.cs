using Application.DTOs.Persona;
using Application.Interfaces.Persona;
namespace Application.Queries.Persona
{
    public class GetPersonaById
    {
        private readonly IPersonaRepository _personaRepository;
        public GetPersonaById(IPersonaRepository personaRepository)
        {
            _personaRepository = personaRepository;
        }
        public async Task<PersonaDTO> Execute(int idPersona)
        {
            return await _personaRepository.GetPersonaById(idPersona);
        }
    }
}