using Inmo.App.DTOs;
using Inmo.App.Interfaces;
using Inmo.Dominio.Entidades;

namespace Inmo.App.Servicios
{
    public class ContratoServ : InterfazContratoServ
    {
        private readonly InterfazContratoRepo _repositorio;

        public ContratoServ(InterfazContratoRepo repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<List<ContratoDTO>> GetAll()
        {
            var contratos = await _repositorio.GetAll();

            return contratos.Select(c => new ContratoDTO
            {
                Id = c.Id,
                FechaInicio = c.FechaInicio,
                FechaFin = c.FechaFin,
                PropiedadId = c.PropiedadId,
                PrecioBase = c.PrecioBase,
                MontoFinal = c.MontoFinal,
                TipoContrato = c.TipoContrato,

                TituloPropiedad = c.Propiedad != null
                    ? c.Propiedad.Titulo
                    : string.Empty

            }).ToList();
        }


        public async Task<ContratoDTO?> GetById(int id)
        {
            var c = await _repositorio.GetById(id);

            if (c == null)
                return null;

            return new ContratoDTO
            {
                Id = c.Id,
                FechaInicio = c.FechaInicio,
                FechaFin = c.FechaFin,
                PropiedadId = c.PropiedadId,
                PrecioBase = c.PrecioBase,
                MontoFinal = c.MontoFinal,
                TipoContrato = c.TipoContrato,

                TituloPropiedad = c.Propiedad != null
                    ? c.Propiedad.Titulo
                    : string.Empty
            };
        }

        public async Task Add(CrearContratoDTO dto)
        {
            var contrato = new Contrato
            {
                FechaInicio = dto.FechaInicio,
                FechaFin = dto.FechaFin,
                PropiedadId = dto.PropiedadId,
                PrecioBase = dto.PrecioBase,
                MontoFinal = dto.MontoFinal,
                TipoContrato = dto.TipoContrato
            };

            await _repositorio.Add(contrato);
        }

        public async Task Update(UpdateContratoDTO dto)
        {
            var contrato = await _repositorio.GetById(dto.Id);

            if (contrato == null)
                throw new Exception("No se encontro el contrato");

            contrato.FechaInicio = dto.FechaInicio;
            contrato.FechaFin = dto.FechaFin;
            contrato.PropiedadId = dto.PropiedadId;
            contrato.PrecioBase = dto.PrecioBase;
            contrato.MontoFinal = dto.MontoFinal;
            contrato.TipoContrato = dto.TipoContrato;

            await _repositorio.Update(contrato);
        }

        public async Task Delete(int id)
        {
            var contrato = await _repositorio.GetById(id);

            if (contrato == null)
                throw new Exception("No se encontro el contrato");

            await _repositorio.Delete(contrato);
        }
    }
}
