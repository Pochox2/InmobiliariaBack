using Inmo.App.Interfaces;
using Inmo.Dominio.Entidades;
using Inmo.App.DTOs;

namespace Inmo.App.Servicios
{
    public class ImagenServ : InterfazImgServ
    {
        private readonly InterfazImgRepo _repo;
        private readonly InterfazPropRepo _propRepo;

        public ImagenServ(InterfazImgRepo repo, InterfazPropRepo propRepo)
        {
            _repo = repo;
            _propRepo = propRepo;
        }

        public async Task<List<PropiedadImgDTO>> GetAll()
        {
            var imgs = await _repo.GetAll();
            return imgs.Select(i => new PropiedadImgDTO
            {
                Id = i.Id,
                Url = i.Url,
            }).ToList();
        }

        public async Task<PropiedadImgDTO?> GetById (int id)
        {
            var imagen = await _repo.GetById(id);
            if (imagen == null) return null;

            return new PropiedadImgDTO
            {
                Id = imagen.Id,
                Url = imagen.Url,
            };
        }

        public async Task Add(CrearPropImgDTO dto)
        {
            var propiedad = await _propRepo.GetById(dto.PropiedadId);

            if (propiedad == null)
                throw new Exception("Propiedad no encontrada");

            var img = new PropiedadImagen
            {
                Url = dto.Url,
                PropiedadId = dto.PropiedadId
            };
            await _repo.Add(img);
        }

        public async Task Update(UpdatePropImgDTO dto)
        {
            var imagen = await _repo.GetById(dto.Id);

            if (imagen == null)
                throw new Exception("Imagen no encontrada");
            imagen.Url = dto.Url;

            await _repo.Update(imagen);
        }

        public async Task Delete (int id)
        {
            var imagen = await _repo.GetById(id);

            if (imagen == null)
                throw new Exception("Imagen no encontrada");
            await _repo.Delete(imagen);
        }
    }
}
