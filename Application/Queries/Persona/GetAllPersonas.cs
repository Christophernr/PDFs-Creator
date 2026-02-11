using Application.DTOs.Persona;
using Application.Interfaces.Persona;

namespace Application.Queries.Persona
{
    public class GetAllPersonas
    {
        private readonly IPersonaRepository _personaRepository;

        public GetAllPersonas(IPersonaRepository personaRepository)
        {
            _personaRepository = personaRepository;
        }

        public async Task<IEnumerable<PersonaDTO>> Execute()
        {
            return await _personaRepository.GetAllPersona();
        }
    }
}
