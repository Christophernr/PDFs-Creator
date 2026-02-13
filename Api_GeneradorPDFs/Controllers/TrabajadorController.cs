using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Application.Services;
using Application.DTOs.Trabajador;
namespace Api_GeneradorPDFs.Controllers
{
    public class TrabajadorController : ControllerBase
    {
        private readonly TrabajadorServices _trabajadorServices;

        public TrabajadorController(TrabajadorServices trabajadorServices)
        {
            _trabajadorServices = trabajadorServices;
        }

        [HttpGet("{idTrabajador}")]
        public async Task<IActionResult> GetTrabajadorById(int idTrabajador)
        {
            try
            {
                return Ok(await _trabajadorServices.GetTrabajadorById(idTrabajador));
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error al obtener el trabajador: " + ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> EditarTrabajador([FromBody] EditarTrabajadorDTO editTrabajadorDTO)
        {
            try
            {
                await _trabajadorServices.EditarTrabajador(editTrabajadorDTO);
                return Ok("Trabajador editado exitosamente");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error al editar el trabajador: " + ex.Message);
            }
        }

        [HttpDelete ("{idTrabajador}")]
        public async Task<IActionResult> EliminarTrabajador(int idTrabajador)
        {
            try
            {
                await _trabajadorServices.EliminarTrabajador(idTrabajador);
                return Ok("Trabajador eliminado exitosamente");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error al eliminar el trabajador: " + ex.Message);
            }
        }
         //[HttpPost]
    }
}