using Inmo.App.DTOs;
using Inmo.App.Interfaces;
using Inmo.Dominio.Entidades;

namespace Inmo.App.Servicios
{
    public class CitaServ : InterfazCitaServ
    {
        private readonly InterfazCitaRepo _repositorio;

        public CitaServ(InterfazCitaRepo repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<List<CitaDTO>> GetAll()
        {
            var citas = await _repositorio.GetAll();

            return citas.Select(c => new CitaDTO
            {
                Id = c.Id,
                FechaHora = c.FechaHora,
                Estado = c.Estado,
                ClienteId = c.ClienteId,
                PropiedadId = c.PropiedadId,

                ClienteNombre = c.Cliente != null
                    ? $"{c.Cliente.Nombre} {c.Cliente.Apellido}"
                    : string.Empty,

                PropiedadTitulo = c.Propiedad != null
                    ? c.Propiedad.Titulo
                    : string.Empty
            }).ToList();
        }

        public async Task<CitaDTO?> GetById(int id)
        {
            var cita = await _repositorio.GetById(id);

            if (cita == null)
                return null;

            return new CitaDTO
            {
                Id = cita.Id,
                FechaHora = cita.FechaHora,
                Estado = cita.Estado,

                ClienteId = cita.ClienteId,
                ClienteNombre = cita.Cliente?.Nombre + " " + cita.Cliente?.Apellido ?? string.Empty,

                PropiedadId = cita.PropiedadId,
                PropiedadTitulo = cita.Propiedad?.Titulo ?? string.Empty
            };
        }

        public async Task Add(CrearCitaDTO dto)
        {
            var cita = new Cita
            {
                FechaHora = dto.FechaHora,
                Estado = dto.Estado,
                ClienteId = dto.ClienteId,
                PropiedadId = dto.PropiedadId
            };

            await _repositorio.Add(cita);
        }

        public async Task Update(UpdateCitaDTO dto)
        {
            var cita = await _repositorio.GetById(dto.Id);

            if (cita == null)
                throw new Exception("No se encontro la cita");

            cita.FechaHora = dto.FechaHora;
            cita.Estado = dto.Estado;
            cita.ClienteId = dto.ClienteId;
            cita.PropiedadId = dto.PropiedadId;

            await _repositorio.Update(cita);
        }

        public async Task Delete(int id)
        {
            var cita = await _repositorio.GetById(id);

            if (cita == null)
                throw new Exception("No se encontro la cita");

            await _repositorio.Delete(cita);
        }

    }
}
