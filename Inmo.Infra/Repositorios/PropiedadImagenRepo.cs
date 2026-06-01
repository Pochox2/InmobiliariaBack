using Inmo.App.Interfaces;
using Inmo.Dominio.Entidades;
using Inmo.Infra.Data;
using Microsoft.EntityFrameworkCore;


namespace Inmo.Infra.Repositorios
{
    public class PropiedadImagenRepo : InterfazImgRepo
    {
        private readonly AppDbContext _context;
        public PropiedadImagenRepo (AppDbContext context)
        {
            _context = context;
        }

        public async Task <List<PropiedadImagen>> GetAll()
        {
            return await _context.PropiedadImagenes.ToListAsync();
        }

        public async Task<PropiedadImagen?> GetById(int id)
        {
            return await _context.PropiedadImagenes.FindAsync(id);
        }

        public async Task Add (PropiedadImagen imagen)
        {
            _context.PropiedadImagenes.Add(imagen);
            await _context.SaveChangesAsync();
        }

        public async Task Update(PropiedadImagen imagen)
        {
            _context.PropiedadImagenes.Update(imagen);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(PropiedadImagen imagen)
        {
            _context.PropiedadImagenes.Remove(imagen);
            await _context.SaveChangesAsync();
        }
    }
}
