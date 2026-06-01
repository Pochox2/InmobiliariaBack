namespace Inmo.Dominio.Entidades
{
    public class Pago
    {
        public int Id { get; set; }
        public int FacturaId { get; set; }
        public Factura? Factura { get; set; }
        public DateTime FechaPago { get; set; }
        public decimal ImportePagado { get; set; }
        public string MetodoPago { get; set; } = string.Empty;
    }
}
