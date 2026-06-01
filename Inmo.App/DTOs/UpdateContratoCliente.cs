using System.ComponentModel.DataAnnotations;

namespace Inmo.App.DTOs
{
    public class UpdateContratoCliente
    {
        [Required(ErrorMessage = "El id es necesario")]
        public int Id { get; set; }

        [Required(ErrorMessage = "El ID del contrato es necesario")]
        public int ContratoId { get; set; }

        [Required(ErrorMessage = "El ID del cliente es necesario")]
        public int ClienteId { get; set; }

        [Required(ErrorMessage = "El rol es necesario")]
        [RegularExpression("Propietario|Inquilino|Comprador|Vendedor", ErrorMessage = "El rol debe ser Propietario, Inquilino, Comprador o Vendedor")]
        public string Rol { get; set; } = string.Empty;
    }
}
