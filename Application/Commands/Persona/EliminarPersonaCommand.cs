using Application.Interfaces.Persona;
namespace Application.Commands.Persona
{
    public class EliminarPersonaCommand
    {
        private readonly IPersonaRepository _personaRepository;

        public EliminarPersonaCommand(IPersonaRepository personaRepository)
        {
            _personaRepository = personaRepository;
        }

        public async Task Execute(int idPersona)
        {
            await _personaRepository.EliminarPersona(idPersona);
        }
    }

}
