using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inmo.Dominio.Entidades;
using Inmo.App.DTOs;
using System.Threading.Tasks;

namespace Inmo.App.Interfaces
{
    public interface InterfazClienteRepo
    {  
        Task<List<Cliente>> GetAll();
        Task Add(Cliente cliente);
        Task<Cliente?> GetById(int id);
        Task Update(Cliente cliente);
        Task Delete(Cliente cliente);
    }
}
