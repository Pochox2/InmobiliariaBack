using Inmo.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inmo.App.Interfaces
{
    public interface InterfazFacturaRepo
    {
        Task<List<Factura>> GetAll();
        Task Add(Factura factura);
        Task<Factura?> GetById(int id);
        Task Update(Factura factura);
        Task Delete(Factura factura);
    }
}
