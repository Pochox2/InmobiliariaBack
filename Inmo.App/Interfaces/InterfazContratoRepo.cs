using Inmo.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inmo.App.Interfaces
{
    public interface InterfazContratoRepo
    {
        Task<List<Contrato>> GetAll();
        Task Add(Contrato contrato);
        Task<Contrato?> GetById(int id);
        Task Update(Contrato contrato);
        Task Delete(Contrato contrato);
    }
}
