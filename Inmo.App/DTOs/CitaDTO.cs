namespace Inmo.App.DTOs
{
    public class CitaDTO
    {
        public int Id { get; set; }
        public DateTime FechaHora { get; set; }
        public string Estado { get; set; } = string.Empty;
        public int ClienteId { get; set; }
        public string ClienteNombre { get; set; } = string.Empty;
        public int PropiedadId { get; set; }
        public string PropiedadTitulo { get; set; } = string.Empty;
    }
}
