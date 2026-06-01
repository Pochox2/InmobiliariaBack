using Microsoft.AspNetCore.Mvc;
using Inmo.App.Interfaces;
using Inmo.App.DTOs;

namespace Inmo.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    
    public class PropiedadesController : ControllerBase
    {
        private readonly InterfazPropServ _servicio;

        public PropiedadesController(InterfazPropServ servicio)
        {
            _servicio = servicio;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var propiedades = await _servicio.GetAll();

            return Ok(propiedades);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var propiedad = await _servicio.GetById(id);
            if (propiedad == null)
                return NotFound();
            return Ok(propiedad);
        }

        [HttpGet("filtrar")]
        public async Task<IActionResult> Filtrar([FromQuery] PropiedadFiltroDTO filtro)
        {
            var resultado = await _servicio.Filtrar(filtro);
            return Ok(resultado);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CrearPropDTO dto)
        {
            await _servicio.Add(dto);

            return Ok(dto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update (int id, UpdatePropDTO dto)
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
