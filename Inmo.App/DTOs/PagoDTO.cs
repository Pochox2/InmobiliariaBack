namespace Inmo.App.DTOs
{
    public class PagoDTO
    {
        public int Id { get; set; }
        public int FacturaId { get; set; }
        public DateTime FechaPago { get; set; }
        public decimal ImportePagado { get; set; }
        public string MetodoPago { get; set; } = string.Empty;
    }
}
