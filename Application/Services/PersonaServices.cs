using Application.Commands.Persona;
using Application.DTOs.Persona;
using Application.Queries.Persona;
namespace Application.Services
{
    public class PersonaServices
    {
        private readonly GetAllPersonas _getAllPersonas;
        private readonly GetPersonaById _getPersona;
        private readonly CreatePersonaCommand _createPersona;
        private readonly EditarPersonaCommand _editarPersona;
        private readonly EliminarPersonaCommand _eliminarPersona;
        public Task<IEnumerable<PersonaDTO>> GetAllPersonasAsync()
        {
            return _getAllPersonas.Execute();
        }

        public Task<PersonaDTO> GetPersonaByIdAsync(int idPersona)
        {
            return _getPersona.Execute(idPersona);
        }

        public Task<int> CreatePersonaAsync(CreatePersonaDTO createPersonaDTO)
        {
            return _createPersona.Execute(createPersonaDTO);
        }

        public Task EditarPersonaAsync(EditarPersonaDTO editarPersonaDTO)
        {
            return _editarPersona.Execute(editarPersonaDTO);
        }

        public Task EliminarPersonaAsync(int idPersona)
        {
            return _eliminarPersona.Execute(idPersona);
        }
    }
}
