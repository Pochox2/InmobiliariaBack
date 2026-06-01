namespace Inmo.App.DTOs
{
    public class FacturaDTO
    {
        public int Id { get; set; }
        public string NroFactura { get; set; } = string.Empty;
        public string TipoFactura { get; set; } = string.Empty;
        public int ClienteId { get; set; }
        public DateTime FechaEmision { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public string Estado { get; set; } = string.Empty;
        public decimal Importe { get; set; }
        public string Operacion { get; set; } = string.Empty;
        public string ClienteNombre { get; set; } = string.Empty;
        public List<PagoDTO> Pagos { get; set; } = new();

    }
}
