using System;
using System.Collections.Generic;
using System.Text;
using Application.DTOs.Estudiante;
using Application.Interfaces.Estudiante;
namespace Application.Commands.Estudiante
{
    public class EditarEstudianteCommand
    {
        private readonly IEstudianteRepository _estudianteRepository;
        public EditarEstudianteCommand(IEstudianteRepository estudianteRepository)
        {
            _estudianteRepository = estudianteRepository;
        }
        public async Task Execute(EditarEstudianteDTO editEstudianteDTO)
        {
            await _estudianteRepository.EditarEstudiante(editEstudianteDTO);
        }
    }
}
