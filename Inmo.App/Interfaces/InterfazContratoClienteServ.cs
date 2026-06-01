using Inmo.App.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inmo.App.Interfaces
{
    public interface InterfazContratoClienteServ
    {
        Task<List<ContratoClienteDTO>> GetAll();
        Task<ContratoClienteDTO?> GetById(int id);

        Task Add(CrearContratoCliente dto);

        Task Update(UpdateContratoCliente dto);

        Task Delete(int id);
    }
}
