using System;
using System.Collections.Generic;
using System.Text;
using Application.DTOs.Trabajador;
using Application.Interfaces.Trabajador;
namespace Application.Queries.Trabajador
{
    public class GetTrabajadorById
    {
        private readonly ITrabajadorRepository _trabajadorRepository;
        public GetTrabajadorById(ITrabajadorRepository trabajadorRepository)
        {
            _trabajadorRepository = trabajadorRepository;
        }
        public async Task<TrabajadorDTO> Execute(int idTrabajador)
        {
            return await _trabajadorRepository.GetTrabajadorById(idTrabajador);
        }
    }
}
