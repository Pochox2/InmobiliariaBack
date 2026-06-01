using System.ComponentModel.DataAnnotations;


namespace Inmo.App.DTOs
{
    public class UpdateContratoDTO
    {
        [Required(ErrorMessage = "El id es necesario")]
        public int Id { get; set; }

        [Required(ErrorMessage = "La fecha de inicio es necesaria")]
        public DateTime FechaInicio { get; set; }

        [Required(ErrorMessage = "La fecha de fin es necesaria")]
        public DateTime FechaFin { get; set; }

        [Required(ErrorMessage = "El ID de la propiedad es necesario")]
        public int PropiedadId { get; set; }

        [Required(ErrorMessage = "El precio base es necesario")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El precio base debe ser mayor a 0")]
        public decimal PrecioBase { get; set; }

        [Required(ErrorMessage = "El monto final es necesario")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El monto final debe ser mayor a 0")]
        public decimal MontoFinal { get; set; }

        [Required(ErrorMessage = "El tipo de contrato es necesario")]
        [RegularExpression("Venta|Alquiler|Temporal", ErrorMessage = "El tipo de contrato debe ser Venta, Alquiler o Temporal")] 
        public string TipoContrato { get; set; } = string.Empty;
    }
}
