using System.ComponentModel.DataAnnotations;

namespace Inmo.App.DTOs
{
    public class CrearClienteDTO
    {
        [Required(ErrorMessage = "El nombre es necesario")]
        [StringLength(100, ErrorMessage = "La cantidad maxima de caracteres son 100")]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "El apellido es necesario")]
        [StringLength(100, ErrorMessage = "La cantidad maxima de caracteres son 100")]
        public string Apellido { get; set; } = string.Empty;


        [Required(ErrorMessage = "El DNI es necesario")]
        [Range(1, 99999999, ErrorMessage = "El DNI no es valido")]
        public int DNI { get; set; }

        [Required(ErrorMessage = "El email es necesario")]
        [StringLength(100, ErrorMessage = "La cantidad maxima de caracteres son 100")]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
       
        [Required(ErrorMessage = "El telefono es necesario")]
        [StringLength(100, ErrorMessage = "La cantidad maxima de caracteres son 100")]
        public string Telefono { get; set; } = string.Empty ;
        
        [Required(ErrorMessage = "El tipo de cliente es necesario")]
        [RegularExpression("Propietario|Inquilino|Comprador|Vendedor", ErrorMessage = "El tipo de cliente debe ser Propietario, Inquilino, Comprador o Vendedor")]
        public string TipoCliente { get; set; } = string.Empty;
    }
}

