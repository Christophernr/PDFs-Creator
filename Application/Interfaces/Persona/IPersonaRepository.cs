using System;
using System.Collections.Generic;
using System.Text;
using Application.DTOs.Persona;
namespace Application.Interfaces.Persona
{
    public interface IPersonaRepository
    {
        Task<IEnumerable<PersonaDTO>> GetAllPersona();
        Task<PersonaDTO> GetPersonaById(int idPersona);
      
        Task<int> CreatePersona(CreatePersonaDTO persona);

        Task<EditarPersonaDTO> EditarPersona(EditarPersonaDTO editarPersonaDTO);

        Task<int> EliminarPersona(int idPersona);
    }
}
