using Inmo.App.Interfaces;
using Inmo.Dominio.Entidades;
using Inmo.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Inmo.Infra.Repositorios
{
    public class ClienteRepo : InterfazClienteRepo
    {
        private readonly AppDbContext _context;
        public ClienteRepo(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Cliente>> GetAll()
        {
            return await _context.Clientes
                .Include(c => c.Citas)
                    .ThenInclude(ci => ci.Propiedad)
                .Include(c => c.ContratoClientes)
                    .ThenInclude(cc => cc.Contrato)
                .ToListAsync();
        }

        public async Task Add(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task<Cliente?> GetById(int id)
        {
            return await _context.Clientes
                .Include (c => c.Citas)
                    .ThenInclude(ci => ci.Propiedad)
                .Include(c => c.ContratoClientes)
                    .ThenInclude(cc => cc.Contrato)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task Update(Cliente cliente)
        {
            _context.Clientes.Update(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Cliente cliente)
        {
            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();
        }
    }
}
