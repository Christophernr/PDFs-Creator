using Application.DTOs.Persona;
//using Application.Queries.Persona;
using Application.Services;
using Microsoft.AspNetCore.Mvc;
namespace Api_GeneradorPDFs.Controllers

{

    [ApiController]
    [Route("api/[controller]")]
    public class PersonaController : ControllerBase
    {


        private readonly PersonaServices _personaServices;

        public PersonaController(PersonaServices personaServices)
        {
            _personaServices = personaServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPersonas()
        {
            try
            {
                //var personas = await getAllPersonas.Execute();
                return Ok(await _personaServices.GetAllPersonasAsync());
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error al obtener las personas: " + ex.Message);
            }
        }

        [HttpGet("{idPersona}")]
        public async Task<IActionResult> GetPersonaById(int idPersona)
        {
            try
            {
                //var persona = await getPersona.Execute(idPersona);
                var persona = await _personaServices.GetPersonaByIdAsync(idPersona);
                if (persona == null)
                {
                    return NotFound("Persona no encontrada");
                }
                return Ok(persona);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error al obtener la persona: " + ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreatePersona([FromBody] CreatePersonaDTO createPersonaDTO)
        {
            try
            {
                //var newPersonaId = await createPersona.Execute(createPersonaDTO);
                var newPersonaId = await _personaServices.CreatePersonaAsync(createPersonaDTO);
                return CreatedAtAction(nameof(GetPersonaById), new { idPersona = newPersonaId }, null);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error al crear la persona: " + ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> EditarPersona([FromBody] EditarPersonaDTO editarPersonaDTO)
        {
            try
            {
                await _personaServices.EditarPersonaAsync(editarPersonaDTO);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error al editar la persona: " + ex.Message);
            }
        }

        [HttpDelete("{idPersona}")]

        public async Task<IActionResult> EliminarPersona(int idPersona)
        {
            try
            {
                await _personaServices.EliminarPersonaAsync(idPersona);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error al eliminar la persona: " + ex.Message);
            }
        }
    }
}
