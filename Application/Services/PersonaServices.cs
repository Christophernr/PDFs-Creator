using Application.DTOs.Persona;
using Application.Queries;
using Application.Queries.Persona;
using System;
using System.Collections.Generic;
using System.Text;
namespace Application.Services
{
    public class PersonaServices
    {
        private readonly GetAllPersonas _getAllPersonas;

        public Task<IEnumerable<PersonaDTO>> GetAllPersonasAsync()
        {
            return _getAllPersonas.Execute();
        }

    }
}
