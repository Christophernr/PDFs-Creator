using System;
using System.Collections.Generic;
using System.Text;
using Application.DTOs.Estudiante;
using Application.Interfaces.Estudiante;
namespace Application.Commands.Estudiante
{
    public class EliminarEstudianteCommand
    {
        private readonly IEstudianteRepository _estudianteRepository;
        public EliminarEstudianteCommand(IEstudianteRepository estudianteRepository)
        {
            _estudianteRepository = estudianteRepository;
        }
        public async Task Execute(int idEstudiante)
        {
            await _estudianteRepository.EliminarEstudiante(idEstudiante);
        }
    }
}