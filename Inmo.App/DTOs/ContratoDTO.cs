namespace Inmo.App.DTOs
{
    public class ContratoDTO
    {
        public int Id { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public int PropiedadId { get; set; }
        public decimal PrecioBase { get; set; }
        public decimal MontoFinal { get; set; }
        public string TipoContrato { get; set; } = string.Empty;
        public string TituloPropiedad { get; set; } = string.Empty ;
    }
}
