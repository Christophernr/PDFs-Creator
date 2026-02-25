using System;
using System.Collections.Generic;
using System.Text;
using Application.DTOs.Estudiante;

namespace Application.Interfaces.Estudiante
{
    public interface IEstudianteRepository
    {
        Task<EstudianteDTO> GetEstudianteById(int idEstudiante);
        // Task<IEnumerable<EstudianteDTO>> GetAllEstudiantes();
        Task EditarEstudiante(EditarEstudianteDTO editarEstudianteDTO);

        Task EliminarEstudiante(int idEstudiante);
    }
}
