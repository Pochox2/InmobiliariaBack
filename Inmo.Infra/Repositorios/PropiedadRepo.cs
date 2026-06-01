using Microsoft.EntityFrameworkCore;
using Inmo.App.Interfaces;
using Inmo.Dominio.Entidades;
using Inmo.Infra.Data;
using Inmo.App.DTOs;

namespace Inmo.Infra.Repositorios
{
    public class PropiedadRepo : InterfazPropRepo
    {
        private readonly AppDbContext _context;

        public PropiedadRepo(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Propiedad>> GetAll()
        {
            return await _context.Propiedades
                .Include(p => p.Imagenes)
                .ToListAsync();
        }

        public async Task Add(Propiedad propiedad)
        {
            _context.Propiedades.Add(propiedad);
            await _context.SaveChangesAsync();
        }
        
        public async Task<Propiedad?> GetById(int id)
        {
            return await _context.Propiedades
                .Include(p => p.Imagenes)
                .FirstOrDefaultAsync(p => p.Id == id);
        } 

        public async Task Update(Propiedad propiedad)
        {
            _context.Propiedades.Update(propiedad);
            await _context.SaveChangesAsync();
        }

        public async Task Delete (Propiedad propiedad)
        {
            _context.Propiedades.Remove(propiedad);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Propiedad>> Filtrar(PropiedadFiltroDTO filtro)
        {
            var query = _context.Propiedades.AsQueryable();

            if (!string.IsNullOrEmpty(filtro.Ciudad))
                query = query.Where(p => p.Ciudad.Contains(filtro.Ciudad));

            if (!string.IsNullOrEmpty(filtro.Tipo))
                query = query.Where(p => p.Tipo.Contains(filtro.Tipo));

            if (!string.IsNullOrEmpty(filtro.Operacion))
                query = query.Where(p => p.Operacion.Contains(filtro.Operacion));

            if (filtro.PrecioMin.HasValue)
                query = query.Where(p => p.Precio >= filtro.PrecioMin.Value);

            if (filtro.PrecioMax.HasValue)
                query = query.Where(p => p.Precio <= filtro.PrecioMax.Value);

            if (filtro.Habitaciones.HasValue)
                query = query.Where(p => p.Habitaciones == filtro.Habitaciones.Value);

            return await query.ToListAsync();
        }
    }
}
