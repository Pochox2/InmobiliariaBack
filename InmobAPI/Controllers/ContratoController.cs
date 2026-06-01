using Inmo.App.DTOs;
using Inmo.App.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Inmo.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContratoController : ControllerBase
    {
        private readonly InterfazContratoServ _servicio;

        public ContratoController(InterfazContratoServ servicio)
        {
            _servicio = servicio;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var contratos = await _servicio.GetAll();

            return Ok(contratos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var contrato = await _servicio.GetById(id);
            if (contrato == null)
                return NotFound();
            return Ok(contrato);
        }


        [HttpPost]
        public async Task<IActionResult> Create(CrearContratoDTO dto)
        {
            await _servicio.Add(dto);

            return Ok(dto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateContratoDTO dto)
        {
            if (id != dto.Id)
                return BadRequest("El id no es el mismo");

            await _servicio.Update(dto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _servicio.Delete(id);
            return Ok();
        }
    }
}
