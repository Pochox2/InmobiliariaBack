using Inmo.App.DTOs;
using Inmo.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inmo.App.Interfaces
{
    public interface InterfazImgRepo
    {
        Task<List<PropiedadImagen>> GetAll();
        Task Add(PropiedadImagen imagen);
        Task<PropiedadImagen?> GetById(int id);
        Task Update(PropiedadImagen imagen);
        Task Delete(PropiedadImagen imagen);
    }
}
