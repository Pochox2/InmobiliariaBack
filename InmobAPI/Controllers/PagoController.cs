using Inmo.App.DTOs;
using Inmo.App.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Inmo.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PagoController : ControllerBase
    {

        private readonly InterfazPagoServ _servicio;

        public  PagoController(InterfazPagoServ servicio)
        {
            _servicio = servicio;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var pagos = await _servicio.GetAll();

            return Ok(pagos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var pago = await _servicio.GetById(id);
            if (pago == null)
                return NotFound();
            return Ok(pago);
        }


        [HttpPost]
        public async Task<IActionResult> Create(CrearPagoDTO dto)
        {
            await _servicio.Add(dto);

            return Ok(dto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdatePagoDTO dto)
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
