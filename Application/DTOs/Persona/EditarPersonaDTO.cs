namespace Application.DTOs.Persona
{
    public class EditarPersonaDTO
    {
        public int idPersona { get; set; }

        public string nombre { get; set; }

        public string apellido { get; set; }

        public string telefono { get; set; }

        public string direccion { get; set; }

        public int tipo { get; set; }

        public DateTime? fechaSalida { get; set; }


        // Estudiante
        public int? SeccionId { get; set; }
        public bool? Nivel { get; set; }

        // Trabajador
        public string? Puesto { get; set; }
        public int? DepartamentoId { get; set; }
    }
}
