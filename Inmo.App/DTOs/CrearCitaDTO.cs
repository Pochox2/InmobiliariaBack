using System.ComponentModel.DataAnnotations;

namespace Inmo.App.DTOs
{
    public class CrearCitaDTO
    {
        [Required(ErrorMessage = "La fecha y la hora son necesarias")]
        public DateTime FechaHora { get; set; }

        [Required(ErrorMessage = "El estado es necesario")]
        [RegularExpression("Agendada|Realizada|Cancelada|Pospuesta", ErrorMessage = "El estado debe ser Agendada, Realizada, Cancelada o Pospuesta")] 
        public string Estado { get; set; } = string.Empty;

        [Required(ErrorMessage = "El ID del cliente es necesario")]
        public int ClienteId { get; set; }

        [Required(ErrorMessage = "El ID de la propiedad es necesario")]
        public int PropiedadId { get; set; }
    }
}
