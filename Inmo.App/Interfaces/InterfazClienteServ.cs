using Inmo.App.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inmo.App.Interfaces
{
    public interface InterfazClienteServ
    {
        Task<List<ClienteDTO>> GetAll();
        Task<ClienteDTO?> GetById(int id);
        Task Add(CrearClienteDTO dto);

        Task Update(UpdateClienteDTO dto);

        Task Delete(int id);
    }
}
