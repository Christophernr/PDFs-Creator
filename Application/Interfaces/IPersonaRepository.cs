using System;
using System.Collections.Generic;
using System.Text;
using Application.DTOs.Persona;
namespace Application.Interfaces
{
    public interface IPersonaRepository
    {
      Task<IEnumerable<PersonaDTO>> GetAllPersona();
    }
}
