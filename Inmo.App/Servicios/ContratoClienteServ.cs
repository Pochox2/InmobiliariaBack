using Inmo.App.DTOs;
using Inmo.App.Interfaces;
using Inmo.Dominio.Entidades;


namespace Inmo.App.Servicios
{
    public class ContratoClienteServ : InterfazContratoClienteServ
    {
        private readonly InterfazContratoClienteRepo _repositorio;

        public ContratoClienteServ(InterfazContratoClienteRepo repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<List<ContratoClienteDTO>> GetAll()
        {
            var contratosClientes = await _repositorio.GetAll();

            return contratosClientes.Select(cc => new ContratoClienteDTO
            {
                Id = cc.Id,
                ContratoId = cc.ContratoId,
                ClienteId = cc.ClienteId,
                Rol = cc.Rol,

                ClienteNombre = cc.Cliente != null
                    ? $"{cc.Cliente.Nombre} {cc.Cliente.Apellido}"
                    : string.Empty,

                TipoContrato = cc.Contrato != null
                    ? cc.Contrato.TipoContrato
                    : string.Empty

            }).ToList();
        }

        public async Task<ContratoClienteDTO?> GetById(int id)
        {
            var cc = await _repositorio.GetById(id);

            if (cc == null)
                return null;

            return new ContratoClienteDTO
            {
                Id = cc.Id,
                ContratoId = cc.ContratoId,
                ClienteId = cc.ClienteId,
                Rol = cc.Rol
            };
        }
    

        public async Task Add(CrearContratoCliente dto)
        {
            var contratoCliente = new ContratoCliente
            {
                ContratoId = dto.ContratoId,
                ClienteId = dto.ClienteId,
                Rol = dto.Rol
            };

            await _repositorio.Add(contratoCliente);
        }

        public async Task Update(UpdateContratoCliente dto)
        {
            var contratoCliente = await _repositorio.GetById(dto.Id);

            if (contratoCliente == null)
                throw new Exception("No se encontro la relacion contrato-cliente");

            contratoCliente.ContratoId = dto.ContratoId;
            contratoCliente.ClienteId = dto.ClienteId;
            contratoCliente.Rol = dto.Rol;

            await _repositorio.Update(contratoCliente);
        }

        public async Task Delete(int id)
        {
            var contratoCliente = await _repositorio.GetById(id);

            if (contratoCliente == null)
                throw new Exception("No se encontro la relacion contrato-cliente");

            await _repositorio.Delete(contratoCliente);
        }
    }
}
