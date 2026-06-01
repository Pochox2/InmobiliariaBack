using Inmo.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inmo.App.Interfaces
{
    public interface InterfazContratoClienteRepo
    {
        Task<List<ContratoCliente>> GetAll();
        Task Add(ContratoCliente contratoCliente);
        Task<ContratoCliente?> GetById(int id);
        Task Update(ContratoCliente contratoCliente);
        Task Delete(ContratoCliente contratoCliente);
    }
}
