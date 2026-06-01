using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inmo.Dominio.Entidades;
using Inmo.App.DTOs;

namespace Inmo.App.Interfaces
{
    public interface InterfazPropRepo
    {
        Task<List<Propiedad>> GetAll();
        Task Add(Propiedad propiedad);  
        Task<Propiedad?> GetById(int id);    
        Task<List<Propiedad>> Filtrar(PropiedadFiltroDTO filtro);
        Task Update(Propiedad propiedad);
        Task Delete(Propiedad propiedad);

    }
}
