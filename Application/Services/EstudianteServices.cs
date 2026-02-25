using System;
using System.Collections.Generic;
using System.Text;
using Application.DTOs.Estudiante;
//using Application.Interfaces.Estudiante;
using Application.Queries.Estudiante;
using Application.Commands.Estudiante;
namespace Application.Services
{
    public class EstudianteServices
    {
        private readonly GetEstudianteById _getEstudianteById;
        private readonly EditarEstudianteCommand _editarEstudianteCommand;
        private readonly EliminarEstudianteCommand _eliminarEstudianteCommand;
        public Task<EstudianteDTO> GetEstudianteById(int idEstudiante)
        {
            return _getEstudianteById.Execute(idEstudiante);
        }

        public Task EditarEstudiante(EditarEstudianteDTO editEstudianteDTO)
        {
            return _editarEstudianteCommand.Execute(editEstudianteDTO);
        }

        public Task EliminarEstudiant(int idEstudiante)
        {
            return _eliminarEstudianteCommand.Execute(idEstudiante);
        }
    }
}
