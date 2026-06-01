using Inmo.App.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inmo.App.Interfaces
{
    public interface InterfazContratoServ
    {
        Task<List<ContratoDTO>> GetAll();
        Task<ContratoDTO?> GetById(int id);
        Task Add(CrearContratoDTO dto);

        Task Update(UpdateContratoDTO dto);

        Task Delete(int id);
    }
}
