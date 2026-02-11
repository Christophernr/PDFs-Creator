using Application.DTOs.Persona;
namespace Application.Interfaces.Persona
{
    public interface IPersonaRepository
    {
        Task<IEnumerable<PersonaDTO>> GetAllPersona();
        Task<PersonaDTO> GetPersonaById(int idPersona);

        Task<int> CreatePersona(CreatePersonaDTO persona);

        Task EditarPersona(EditarPersonaDTO editarPersonaDTO);

        Task EliminarPersona(int idPersona);
    }
}
