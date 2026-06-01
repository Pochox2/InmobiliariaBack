using Inmo.App.DTOs;
using Inmo.App.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Inmo.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FacturaController : ControllerBase
    {
        private readonly InterfazFacturaServ _servicio;

        public FacturaController(InterfazFacturaServ servicio)
        {
            _servicio = servicio;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var facturas = await _servicio.GetAll();

            return Ok(facturas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var factura = await _servicio.GetById(id);
            if (factura == null)
                return NotFound();
            return Ok(factura);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CrearFacturaDTO dto)
        {
            await _servicio.Add(dto);

            return Ok(dto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateFacturaDTO dto)
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
