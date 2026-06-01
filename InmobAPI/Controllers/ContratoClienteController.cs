using Inmo.App.DTOs;
using Inmo.App.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Inmo.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContratoClienteController : ControllerBase
    {
        private readonly InterfazContratoClienteServ _servicio;

        public ContratoClienteController(InterfazContratoClienteServ servicio)
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
            var cc = await _servicio.GetById(id);
            if (cc == null)
                return NotFound();
            return Ok(cc);
        }



        [HttpPost]
        public async Task<IActionResult> Create(CrearContratoCliente dto)
        {
            await _servicio.Add(dto);

            return Ok(dto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateContratoCliente dto)
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
