using Inmo.App.DTOs;
using Inmo.App.Interfaces;
using Inmo.Dominio.Entidades;


namespace Inmo.App.Servicios
{
    public class PagoServ : InterfazPagoServ
    {
        private readonly InterfazPagoRepo _repositorio;

        public PagoServ(InterfazPagoRepo repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<List<PagoDTO>> GetAll()
        {
            var pagos = await _repositorio.GetAll();

            return pagos.Select(p => new PagoDTO
            {
                Id = p.Id,
                FacturaId = p.FacturaId,
                FechaPago = p.FechaPago,
                ImportePagado = p.ImportePagado,
                MetodoPago = p.MetodoPago
            }).ToList();
        }

        public async Task<PagoDTO?> GetById(int id)
        {
            var pago = await _repositorio.GetById(id);

            if (pago == null)
                return null;

            return new PagoDTO
            {
                Id = pago.Id,
                FacturaId = pago.FacturaId,
                FechaPago = pago.FechaPago,
                ImportePagado = pago.ImportePagado,
                MetodoPago = pago.MetodoPago
            };
        }

        public async Task Add(CrearPagoDTO dto)
        {
            var pago = new Pago
            {
                FacturaId = dto.FacturaId,
                FechaPago = dto.FechaPago,
                ImportePagado = dto.ImportePagado,
                MetodoPago = dto.MetodoPago
            };

            await _repositorio.Add(pago);
        }
        // futuras validaciones
        public async Task Update(UpdatePagoDTO dto)
        {
            var pago = await _repositorio.GetById(dto.Id);

            if (pago == null)
                throw new Exception("No se encontro el pago");

            pago.FacturaId = dto.FacturaId;
            pago.FechaPago = dto.FechaPago;
            pago.ImportePagado = dto.ImportePagado;
            pago.MetodoPago = dto.MetodoPago;

            await _repositorio.Update(pago);
        }

        public async Task Delete(int id)
        {
            var pago = await _repositorio.GetById(id);

            if (pago == null)
                throw new Exception("No se encontro el pago");

            await _repositorio.Delete(pago);
        }



}
}
