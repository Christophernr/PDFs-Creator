using Application.Services;
using Application.DTOs.Estudiante;
using Microsoft.AspNetCore.Mvc;
namespace Api_GeneradorPDFs.Controllers
{
    public class EstudianteController: ControllerBase
    {

        private readonly EstudianteServices _estudianteServices;
        public EstudianteController(EstudianteServices estudianteServices)
        {
            _estudianteServices = estudianteServices;
        }
        [HttpGet("{idEstudiante}")]
        public async Task<IActionResult> GetEstudianteById(int idEstudiante)
        {
            try
            {
                return Ok(await _estudianteServices.GetEstudianteById(idEstudiante));
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error al obtener el estudiante: " + ex.Message);
            }
        }

        [HttpPut]

        public async Task<IActionResult> EditarEstudiante([FromBody] EditarEstudianteDTO editEstudianteDTO)
        {
            try
            {
                await _estudianteServices.EditarEstudiante(editEstudianteDTO);
                return Ok("Estudiante editado exitosamente");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error al editar el estudiante: " + ex.Message);
            }
        }

        [HttpDelete ("{idEstudiante}")]

        public async Task<IActionResult> EliminarEstudiante(int idEstudiante)
        {
            try
            {
                await _estudianteServices.EliminarEstudiant(idEstudiante);
                return Ok("Estudiante eliminado exitosamente");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error al eliminar el estudiante: " + ex.Message);
            }
        }
        // [HttpPost]
        //public async Task<IActionResult> CreateEstudiante([FromBody] CreateEstudianteDTO createEstudianteDTO)
        //{
        //    try
        //    {
        //        var newEstudianteId = await _estudianteServices.CreateEstudianteAsync(createEstudianteDTO);
        //        return Ok(new { Id = newEstudianteId });
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, "Error al crear el estudiante: " + ex.Message);
        //    }
        //}
    }
}
