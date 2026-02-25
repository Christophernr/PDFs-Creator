using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs.Trabajador
{
    public class EditarTrabajadorDTO
    {
        public int idTrabajador { get; set; }

        //public int idPersona { get; set; }
        public string puesto { get; set; }
        public int departamentoId { get; set; }
    }
}
