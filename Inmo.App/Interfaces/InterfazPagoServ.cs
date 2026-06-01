using Inmo.App.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inmo.App.Interfaces
{
    public interface InterfazPagoServ
    {
        Task<List<PagoDTO>> GetAll();
        Task<PagoDTO?> GetById(int id);
        Task Add(CrearPagoDTO dto);
        Task Update(UpdatePagoDTO dto);
        Task Delete(int id);
    }
}
