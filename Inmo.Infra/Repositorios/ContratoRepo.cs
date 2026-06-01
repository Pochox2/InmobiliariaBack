using Inmo.App.Interfaces;
using Inmo.Dominio.Entidades;
using Inmo.Infra.Data;
using Microsoft.EntityFrameworkCore;


namespace Inmo.Infra.Repositorios
{
    public class ContratoRepo : InterfazContratoRepo
    {
        private readonly AppDbContext _context;

        public ContratoRepo(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Contrato>> GetAll()
        {
            return await _context.Contratos
                .Include(c => c.Propiedad)
                .Include(c => c.ContratoClientes)
                .ToListAsync();
        }

        public async Task Add(Contrato contrato)
        {
            _context.Contratos.Add(contrato);
            await _context.SaveChangesAsync();
        }

        public async Task<Contrato?> GetById(int id)
        {
            return await _context.Contratos
                .Include(c => c.Propiedad)
                .Include(c => c.ContratoClientes)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task Update(Contrato contrato)
        {
            _context.Contratos.Update(contrato);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Contrato contrato)
        {
            _context.Contratos.Remove(contrato);
            await _context.SaveChangesAsync();
        }
    }
}
