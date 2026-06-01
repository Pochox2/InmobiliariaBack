using Inmo.App.Interfaces;
using Inmo.Dominio.Entidades;
using Inmo.Infra.Data;
using Microsoft.EntityFrameworkCore;


namespace Inmo.Infra.Repositorios
{
    public class ContratoClienteRepo : InterfazContratoClienteRepo
    {
        private readonly AppDbContext _context;

        public ContratoClienteRepo(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<ContratoCliente>> GetAll()
        {
            return await _context.ContratoClientes
                .Include(cc => cc.Contrato)
                .Include(cc => cc.Cliente)
                .ToListAsync();
        }

        public async Task Add(ContratoCliente contratoCliente)
        {
            _context.ContratoClientes.Add(contratoCliente);
            await _context.SaveChangesAsync();
        }

        public async Task<ContratoCliente?> GetById(int id)
        {
            return await _context.ContratoClientes
                .Include(cc => cc.Contrato)
                .Include(cc => cc.Cliente)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task Update(ContratoCliente contratoCliente)
        {
            _context.ContratoClientes.Update(contratoCliente);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(ContratoCliente contratoCliente)
        {
            _context.ContratoClientes.Remove(contratoCliente);
            await _context.SaveChangesAsync();
        }
    }
}
