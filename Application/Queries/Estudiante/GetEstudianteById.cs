using System;
using System.Collections.Generic;
using System.Text;
using Application.DTOs.Estudiante;
using Application.Interfaces.Estudiante;
namespace Application.Queries.Estudiante
{
    public class GetEstudianteById
    {
        private readonly IEstudianteRepository _estudianteRepository;
        public GetEstudianteById(IEstudianteRepository estudianteRepository)
        {
            _estudianteRepository = estudianteRepository;
        }
        public async Task<EstudianteDTO> Execute(int idEstudiante)
        {
            return await _estudianteRepository.GetEstudianteById(idEstudiante);
        }
    }
}
