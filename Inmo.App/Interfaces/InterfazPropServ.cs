using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inmo.App.DTOs;
using Inmo.Dominio.Entidades;

namespace Inmo.App.Interfaces
{
    public interface InterfazPropServ
    {
        Task<List<PropiedadDTO>> GetAll();
        Task<PropiedadDTO?> GetById(int id);
        Task Add(CrearPropDTO dto);
        Task Update(UpdatePropDTO dto);
        Task Delete(int id);
        Task<List<PropiedadDTO>> Filtrar(PropiedadFiltroDTO filtro);
    }
}
