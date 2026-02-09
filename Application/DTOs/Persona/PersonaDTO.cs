using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs.Persona
{
    public class PersonaDTO
    {
        public int Id { get; set; }

        public string nombre { get; set; }

        public string apellido {  get; set; }

        public string telefono { get; set; }

        public string direccion {  get; set; }

        public int tipo { get; set; }
    }
}
