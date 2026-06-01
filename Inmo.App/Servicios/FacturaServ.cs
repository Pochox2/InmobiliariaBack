using Inmo.App.DTOs;
using Inmo.App.Interfaces;
using Inmo.Dominio.Entidades;


namespace Inmo.App.Servicios
{
    public class FacturaServ : InterfazFacturaServ
    {
        private readonly InterfazFacturaRepo _repositorio;

        public FacturaServ(InterfazFacturaRepo repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<List<FacturaDTO>> GetAll()
        {
            var facturas = await _repositorio.GetAll();

            return facturas.Select(f => new FacturaDTO
            {
                Id = f.Id,
                NroFactura = f.NroFactura,
                TipoFactura = f.TipoFactura,
                ClienteId = f.ClienteId,
                FechaEmision = f.FechaEmision,
                FechaVencimiento = f.FechaVencimiento,
                Estado = f.Estado,
                Importe = f.Importe,
                Operacion = f.Operacion,

                ClienteNombre = f.Cliente != null
                    ? $"{f.Cliente.Nombre} {f.Cliente.Apellido}"
                    : string.Empty,
                Pagos = f.Pagos.Select(p => new PagoDTO
                {
                    Id = p.Id,
                    FacturaId = p.FacturaId,
                    FechaPago = p.FechaPago,
                    ImportePagado = p.ImportePagado,
                    MetodoPago = p.MetodoPago
                }).ToList()

            }).ToList();
        }

        public async Task<FacturaDTO?> GetById(int id)
        {
            var factura = await _repositorio.GetById(id);

            if (factura == null)
                return null;

            return new FacturaDTO
            {
                Id = factura.Id,
                NroFactura = factura.NroFactura,
                TipoFactura = factura.TipoFactura,

                ClienteId = factura.ClienteId,
                ClienteNombre = factura.Cliente?.Nombre ?? string.Empty,

                FechaEmision = factura.FechaEmision,
                FechaVencimiento = factura.FechaVencimiento,
                Estado = factura.Estado,
                Importe = factura.Importe,
                Operacion = factura.Operacion,

                Pagos = factura.Pagos.Select(p => new PagoDTO
                {
                    Id = p.Id,
                    FacturaId = p.FacturaId,
                    FechaPago = p.FechaPago,
                    ImportePagado = p.ImportePagado,
                    MetodoPago = p.MetodoPago
                }).ToList()
            };
        }

        public async Task Add(CrearFacturaDTO dto)
        {
            var factura = new Factura
            {
                NroFactura = dto.NroFactura,
                TipoFactura = dto.TipoFactura,
                ClienteId = dto.ClienteId,
                FechaEmision = dto.FechaEmision,
                FechaVencimiento = dto.FechaVencimiento,
                Estado = dto.Estado,
                Importe = dto.Importe,
                Operacion = dto.Operacion
            };

            await _repositorio.Add(factura);
        }

        public async Task Update(UpdateFacturaDTO dto)
        {
            var factura = await _repositorio.GetById(dto.Id);

            if (factura == null)
                throw new Exception("No se encontro la factura");

            factura.NroFactura = dto.NroFactura;
            factura.TipoFactura = dto.TipoFactura;
            factura.ClienteId = dto.ClienteId;
            factura.FechaEmision = dto.FechaEmision;
            factura.FechaVencimiento = dto.FechaVencimiento;
            factura.Estado = dto.Estado;
            factura.Importe = dto.Importe;
            factura.Operacion = dto.Operacion;

            await _repositorio.Update(factura);
        }

        public async Task Delete(int id)
        {
            var factura = await _repositorio.GetById(id);

            if (factura == null)
                throw new Exception("No se encontro la factura");

            await _repositorio.Delete(factura);
        }
    }
    }
