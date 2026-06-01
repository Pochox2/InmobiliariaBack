using Inmo.App.Interfaces;
using Inmo.Dominio.Entidades;
using Inmo.Infra.Data;
using Microsoft.EntityFrameworkCore;


namespace Inmo.Infra.Repositorios
{
    public class PagoRepo : InterfazPagoRepo
    {
        private readonly AppDbContext _context;
        public PagoRepo(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Pago>> GetAll()
        {
            return await _context.Pagos
                .ToListAsync();
        }


        public async Task Add(Pago pago)
        {
            _context.Pagos.Add(pago);
            await _context.SaveChangesAsync();
        }

        public async Task<Pago?> GetById(int id)
        {
            return await _context.Pagos
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task Update(Pago pago)
        {
            _context.Pagos.Update(pago);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Pago pago)
        {
            _context.Pagos.Remove(pago);
            await _context.SaveChangesAsync();
        }
    }
}

