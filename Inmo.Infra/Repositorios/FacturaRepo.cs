using Inmo.App.Interfaces;
using Inmo.Dominio.Entidades;
using Inmo.Infra.Data;
using Microsoft.EntityFrameworkCore;


namespace Inmo.Infra.Repositorios
{
    public class FacturaRepo : InterfazFacturaRepo
    {
        private readonly AppDbContext _context;

        public FacturaRepo(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Factura>> GetAll()
        {
            return await _context.Facturas
                .Include(f => f.Cliente)
                .Include(f => f.Pagos)
                .ToListAsync();
        }

        public async Task Add(Factura factura)
        {
            _context.Facturas.Add(factura);
            await _context.SaveChangesAsync();
        }

        public async Task<Factura?> GetById(int id)
        {
            return await _context.Facturas
                .Include(f => f.Cliente)
                .Include(f => f.Pagos)
                .FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task Update(Factura factura)
        {
            _context.Facturas.Update(factura);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Factura factura)
        {
            _context.Facturas.Remove(factura);
            await _context.SaveChangesAsync();
        }
    }
}
