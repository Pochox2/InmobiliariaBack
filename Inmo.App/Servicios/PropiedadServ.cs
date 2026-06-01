using Inmo.App.Interfaces;
using Inmo.Dominio.Entidades;
using Inmo.App.DTOs;


namespace Inmo.App.Servicios
{
    public class PropiedadServ : InterfazPropServ
    {
        private readonly InterfazPropRepo _repositorio;

        public PropiedadServ(InterfazPropRepo repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<List<PropiedadDTO>> GetAll()
        {
            var propiedades = await _repositorio.GetAll();

            return propiedades.Select(p => new PropiedadDTO
            {
                Id = p.Id,
                Titulo = p.Titulo,
                Descripcion = p.Descripcion,
                Tipo = p.Tipo,
                Operacion = p.Operacion,
                Precio = p.Precio,
                Direccion = p.Direccion,
                Ciudad = p.Ciudad,
                MetrosCuadrados = p.MetrosCuadrados,
                Habitaciones = p.Habitaciones,
                Banos = p.Banos,
                Estado = p.Estado,

                Imagenes = p.Imagenes.Select(i => new PropiedadImgDTO
                {
                Id=i.Id,
                Url= i.Url,
                }).ToList()
            }).ToList();
        }

        public async Task<PropiedadDTO?> GetById(int id)
        {
            var propiedad = await _repositorio.GetById(id);
            if (propiedad == null) return null;

            return new PropiedadDTO
            {
                Id = propiedad.Id,
                Titulo = propiedad.Titulo,
                Descripcion = propiedad.Descripcion,
                Tipo = propiedad.Tipo,
                Operacion = propiedad.Operacion,
                Precio = propiedad.Precio,
                Direccion = propiedad.Direccion,
                Ciudad = propiedad.Ciudad,
                MetrosCuadrados = propiedad.MetrosCuadrados,
                Habitaciones = propiedad.Habitaciones,
                Banos = propiedad.Banos,
                Estado = propiedad.Estado,

                Imagenes = propiedad.Imagenes?
                    .Select(i => new PropiedadImgDTO
                    {
                        Id = i.Id,
                        Url = i.Url
                    }).ToList() ?? new List<PropiedadImgDTO>()
            };
        }


        public async Task Add (CrearPropDTO dto)
        {
            var propiedad = new Propiedad
            {
                Titulo = dto.Titulo,
                Descripcion = dto.Descripcion,
                Tipo = dto.Tipo,
                Operacion = dto.Operacion,
                Precio = dto.Precio,
                Direccion = dto.Direccion,
                Ciudad = dto.Ciudad,
                MetrosCuadrados = dto.MetrosCuadrados,
                Habitaciones = dto.Habitaciones,
                Banos = dto.Banos,
                Estado = dto.Estado,

                Imagenes = dto.Imagenes.Select(url => new PropiedadImagen
                {
                    Url = url,
                }).ToList()
            };

            await _repositorio.Add(propiedad);
         // futuras validaciones

        }

        public async Task Update(UpdatePropDTO dto)
        {
            var propiedad = await _repositorio.GetById(dto.Id);

            if (propiedad == null)
                throw new Exception("No se encontro la propiedad");

            propiedad.Titulo = dto.Titulo;
            propiedad.Descripcion = dto.Descripcion;
            propiedad.Tipo = dto.Tipo;
            propiedad.Operacion = dto.Operacion;
            propiedad.Precio = dto.Precio;
            propiedad.Direccion = dto.Direccion;
            propiedad.Ciudad = dto.Ciudad;
            propiedad.MetrosCuadrados = dto.MetrosCuadrados;
            propiedad.Habitaciones = dto.Habitaciones;
            propiedad.Banos = dto.Banos;
            propiedad.Estado = dto.Estado;

            await _repositorio.Update(propiedad);
        }

        public async Task Delete (int id)
        {
            var propiedad = await _repositorio.GetById(id);

            if (propiedad == null)
                throw new Exception("No se encontro la propiedad");

            await _repositorio.Delete(propiedad);
        }

        public async Task<List<PropiedadDTO>> Filtrar(PropiedadFiltroDTO filtro)
        {
            var propiedades = await _repositorio.Filtrar(filtro);

            return propiedades.Select(p => new PropiedadDTO
            {
                Id = p.Id,
                Titulo = p.Titulo,
                Precio = p.Precio,
                Ciudad = p.Ciudad
            }).ToList();
        }
    }
}
