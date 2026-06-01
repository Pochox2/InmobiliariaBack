using Inmo.App.DTOs;
using Inmo.App.Interfaces;
using Inmo.Dominio.Entidades;

namespace Inmo.App.Servicios
{
    public class ClienteServ : InterfazClienteServ
    {
        private readonly InterfazClienteRepo _repositorio;

        public ClienteServ(InterfazClienteRepo repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<List<ClienteDTO>> GetAll()
        {
            var clientes = await _repositorio.GetAll();

            return clientes.Select(c => new ClienteDTO
            {
                Id = c.Id,
                Nombre = c.Nombre,
                Apellido = c.Apellido,
                DNI = c.DNI,
                Email = c.Email,
                Telefono = c.Telefono,
                TipoCliente = c.TipoCliente,

                Citas = c.Citas.Select(ci => new CitaDTO
                {
                    Id = ci.Id,
                    ClienteId = ci.ClienteId,
                    PropiedadId = ci.PropiedadId,
                    FechaHora = ci.FechaHora,
                    Estado = ci.Estado,
                    ClienteNombre = $"{c.Nombre} {c.Apellido}",
                    PropiedadTitulo = ci.Propiedad != null
                    ? ci.Propiedad.Titulo
                    : string.Empty
                }).ToList(),

                Contratos = c.ContratoClientes?
                    .Select(cc => new ContratoClienteDTO
                    {
                        Id = cc.Id,
                        ClienteId = cc.ClienteId,
                        ContratoId = cc.ContratoId,
                        Rol = cc.Rol,
                          ClienteNombre = cc.Cliente != null
                            ? $"{cc.Cliente.Nombre} {cc.Cliente.Apellido}"
                            : "",

                        TipoContrato = cc.Contrato != null
                            ? cc.Contrato.TipoContrato
                            : ""
                    }).ToList() ?? new List<ContratoClienteDTO>()
            }).ToList();
        }

        public async Task<ClienteDTO?> GetById(int id)
        {
            var cliente = await _repositorio.GetById(id);

            if (cliente == null)
                return null;

            return new ClienteDTO
            {
                Id = cliente.Id,
                Nombre = cliente.Nombre,
                Apellido = cliente.Apellido,
                DNI = cliente.DNI,
                Email = cliente.Email,
                Telefono = cliente.Telefono,
                TipoCliente = cliente.TipoCliente,

                Citas = cliente.Citas.Select(c => new CitaDTO
                {
                    Id = c.Id,
                    ClienteId = c.ClienteId,
                    PropiedadId = c.PropiedadId,
                    FechaHora = c.FechaHora,
                    Estado = c.Estado,
                    ClienteNombre = $"{cliente.Nombre} {cliente.Apellido}",
                    PropiedadTitulo = c.Propiedad != null
                    ? c.Propiedad.Titulo
                    : string.Empty
                }).ToList(),

                Contratos = cliente.ContratoClientes.Select(cc => new ContratoClienteDTO
                {
                    Id = cc.Id,
                    ClienteId = cc.ClienteId,
                    ContratoId = cc.ContratoId,
                    Rol = cc.Rol,
                    ClienteNombre = cc.Cliente != null
                        ? $"{cc.Cliente.Nombre} {cc.Cliente.Apellido}"
                        : "",

                    TipoContrato = cc.Contrato != null
                        ? cc.Contrato.TipoContrato
                        : ""
                }).ToList()
            };
        }

        public async Task Add(CrearClienteDTO dto)
        {
            var cliente = new Cliente
            {
                Nombre = dto.Nombre,
                Apellido = dto.Apellido,
                DNI = dto.DNI,
                Email = dto.Email,
                Telefono = dto.Telefono,
                TipoCliente = dto.TipoCliente
            };

            await _repositorio.Add(cliente);
        }
        // futuras validaciones
        public async Task Update(UpdateClienteDTO dto)
        {
            var cliente = await _repositorio.GetById(dto.Id);

            if (cliente == null)
                throw new Exception("No se encontro el cliente");

            cliente.Nombre = dto.Nombre;
            cliente.Apellido = dto.Apellido;
            cliente.DNI = dto.DNI;
            cliente.Email = dto.Email;
            cliente.Telefono = dto.Telefono;
            cliente.TipoCliente = dto.TipoCliente;

            await _repositorio.Update(cliente);
        }

        public async Task Delete(int id)
        {
            var cliente = await _repositorio.GetById(id);

            if (cliente == null)
                throw new Exception("No se encontro el cliente");

            await _repositorio.Delete(cliente);
        }

    
    
    }

}
