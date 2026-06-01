namespace Inmo.Dominio.Entidades
{
    public class Cita
    {
        public int Id { get; set; }
        public DateTime FechaHora { get; set; }
        public string Estado { get; set; } = string.Empty;
        public int ClienteId { get; set; }
        public Cliente? Cliente { get; set; }
        public int PropiedadId { get; set;}
        public Propiedad? Propiedad { get; set; }
    }
}
