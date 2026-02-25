using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs.Estudiante
{
    public class EditarEstudianteDTO
    {
        public int Id { get; set; }

        //public int IdPersona { get; set; }

        public int seccionID { get; set; }

        public int nivel { get; set; }
    }
}
