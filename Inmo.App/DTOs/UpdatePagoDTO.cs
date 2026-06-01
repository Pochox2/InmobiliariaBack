using System.ComponentModel.DataAnnotations;


namespace Inmo.App.DTOs
{
    public class UpdatePagoDTO
    {
        [Required(ErrorMessage = "El id es necesario")]
        public int Id { get; set; }

        [Required(ErrorMessage = "El ID de la factura es necesario")]
        public int FacturaId { get; set; }

        [Required(ErrorMessage = "La fecha de pago es necesaria")]
        public DateTime FechaPago { get; set; }

        [Required(ErrorMessage = "El importe pagado es necesario")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El importe debe ser mayor a 0")]
        public decimal ImportePagado { get; set; }

        [Required(ErrorMessage = "El metodo de pago es necesario")]
        [RegularExpression("Efectivo|Transferencia|Tarjeta", ErrorMessage = "El método de pago debe ser Efectivo, Transferencia o Tarjeta")]
        public string MetodoPago { get; set; } = string.Empty;
    }
}
