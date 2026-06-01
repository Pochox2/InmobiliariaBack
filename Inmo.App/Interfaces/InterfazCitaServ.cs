using Inmo.App.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inmo.App.Interfaces
{
    public interface InterfazCitaServ
    {
        Task<List<CitaDTO>> GetAll();
        Task<CitaDTO?> GetById(int id);
        Task Add(CrearCitaDTO dto);
        Task Update(UpdateCitaDTO dto);
        Task Delete(int id);
    }
}
