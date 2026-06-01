using Inmo.App.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inmo.App.Interfaces
{
    public interface InterfazFacturaServ
    {
        Task<List<FacturaDTO>> GetAll();
        Task<FacturaDTO?> GetById(int id);
        Task Add(CrearFacturaDTO dto);

        Task Update(UpdateFacturaDTO dto);

        Task Delete(int id);
    }
}
