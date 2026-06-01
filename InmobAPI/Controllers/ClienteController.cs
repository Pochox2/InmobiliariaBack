using Inmo.App.DTOs;
using Inmo.App.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Inmo.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
            private readonly InterfazClienteServ _servicio;

            public ClienteController(InterfazClienteServ servicio)
            {
                _servicio = servicio;
            }

            [HttpGet]
            public async Task<IActionResult> GetAll()
            {
                var clientes = await _servicio.GetAll();

                return Ok(clientes);
            }

            [HttpGet("{id}")]
            public async Task<IActionResult> GetById(int id)
            {
                var cliente = await _servicio.GetById(id);
                if (cliente == null)
                    return NotFound();
                return Ok(cliente);
            }


        [HttpPost]
            public async Task<IActionResult> Create(CrearClienteDTO dto)
            {
                await _servicio.Add(dto);

                return Ok(dto);
            }

            [HttpPut("{id}")]
            public async Task<IActionResult> Update(int id, UpdateClienteDTO dto)
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

