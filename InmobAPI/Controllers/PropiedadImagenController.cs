using Inmo.App.DTOs;
using Inmo.App.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Inmo.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PropiedadImagenController : ControllerBase
    {
        private readonly InterfazImgServ _serv;

        public PropiedadImagenController(InterfazImgServ serv)
        {
            _serv = serv;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _serv.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var imagen = await _serv.GetById(id);
            if (imagen == null) 
                return NotFound();
            return Ok(imagen);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CrearPropImgDTO dto)
        {
            await _serv.Add(dto);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdatePropImgDTO dto)
        {
            await _serv.Update(dto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _serv.Delete(id);
            return Ok();
        }
    }
}
