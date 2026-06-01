using System.ComponentModel.DataAnnotations;


namespace Inmo.App.DTOs
{
    public class CrearFacturaDTO
    {
        [Required(ErrorMessage ="El numero de factura es necesario")]
        [StringLength(100, ErrorMessage = "La cantidad maxima de caracteres son 100")]
        public string NroFactura { get; set; } = string.Empty;

        [Required(ErrorMessage = "El tipo de factura es necesario")]
        [RegularExpression("A|B|C", ErrorMessage = "El tipo de factura debe ser A, B o C")] 
        public string TipoFactura { get; set; } = string.Empty;

        [Required(ErrorMessage ="El ID del cliente es necesario")]
        public int ClienteId { get; set; }

        [Required(ErrorMessage = "La fecha de emision es necesaria")]
        public DateTime FechaEmision { get; set; }

        [Required(ErrorMessage = "La fecha de vencimiento es necesaria")]
        public DateTime FechaVencimiento { get; set; }

        [Required(ErrorMessage = "El estado es necesario")]
        [RegularExpression("Pendiente|Pagada|Vencida|Anulada", ErrorMessage = "El estado debe ser Pendiente, Pagada, Vencida o Anulada")]
        public string Estado { get; set; } = string.Empty;

        [Required(ErrorMessage = "El importe es necesario")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El importe debe ser mayor a 0")]
        public decimal Importe { get; set; }

        [Required(ErrorMessage = "El tipo de operacion es necesario")]
        [RegularExpression("Venta|Alquiler", ErrorMessage = "La operación debe ser Venta o Alquiler")]
        public string Operacion { get; set; } = string.Empty;

    }
}
