using Microsoft.AspNetCore.Mvc;
//using Application.Queries.Persona;
using Application.Services;
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

    }
}
