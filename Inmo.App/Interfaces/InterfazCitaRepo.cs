using Inmo.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inmo.App.Interfaces
{
    public interface InterfazCitaRepo
    {
        Task<List<Cita>> GetAll();
        Task Add(Cita cita);
        Task<Cita?> GetById(int id);
        Task Update(Cita cita);
        Task Delete(Cita cita);
    }
}
