using Inmo.App.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inmo.App.Interfaces
{
    public interface InterfazImgServ
    {
        Task<List<PropiedadImgDTO>> GetAll();
        Task<PropiedadImgDTO?> GetById(int id);
        Task Add(CrearPropImgDTO dto);
        Task Update(UpdatePropImgDTO dto);
        Task Delete(int id);
    }
}
