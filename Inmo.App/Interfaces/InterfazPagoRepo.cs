using Inmo.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inmo.App.Interfaces
{
    public interface InterfazPagoRepo
    {
        Task<List<Pago>> GetAll();
        Task Add(Pago pago);
        Task<Pago?> GetById(int id);
        Task Update(Pago pago);
        Task Delete(Pago pago);
    }
}
