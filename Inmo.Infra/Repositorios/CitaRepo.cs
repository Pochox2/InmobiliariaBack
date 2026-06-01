using Inmo.App.Interfaces;
using Inmo.Dominio.Entidades;
using Inmo.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Inmo.Infra.Repositorios
{
    public class CitaRepo : InterfazCitaRepo
    {
        private readonly AppDbContext _context;

        public CitaRepo(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Cita>> GetAll()
        {
            return await _context.Citas
                .Include(c => c.Cliente)
                .Include(c => c.Propiedad)
                .ToListAsync();
        }

        public async Task Add(Cita cita)
        {
            _context.Citas.Add(cita);
            await _context.SaveChangesAsync();
        }

        public async Task<Cita?> GetById(int id)
        {
            return await _context.Citas
                .Include(c => c.Cliente)
                .Include(c => c.Propiedad)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task Update(Cita cita)
        {
            _context.Citas.Update(cita);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Cita cita)
        {
            _context.Citas.Remove(cita);
            await _context.SaveChangesAsync();
        }
    }
}
