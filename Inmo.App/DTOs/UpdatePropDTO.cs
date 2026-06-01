using System.ComponentModel.DataAnnotations;


namespace Inmo.App.DTOs
{
    public class UpdatePropDTO
    {
        [Required(ErrorMessage = "El id es necesario")]
        public int Id { get; set; } 


        [Required(ErrorMessage = "El titulo es necesario.")]
        [StringLength(100, ErrorMessage = "La cantidad maxima de caracteres para el titulo son 100")]
        public string Titulo { get; set; } = string.Empty;

        [Required(ErrorMessage = "La descripcion es necesaria.")]
        [StringLength(500, ErrorMessage = "La cantidad maxima de caracteres para la descripcion son 500")]
        public string Descripcion { get; set; } = string.Empty;

        [Required(ErrorMessage = "El tipo es necesario.")]
        [RegularExpression("Casa|Departamento|Terreno|Local", ErrorMessage = "El tipo debe ser Casa, Departamento, Terreno o Local")]
        public string Tipo { get; set; } = string.Empty;

        [Required(ErrorMessage = "La operacion es necesaria.")]
        [RegularExpression("Venta|Alquiler", ErrorMessage = "La operación debe ser Venta o Alquiler")]
        public string Operacion { get; set; } = string.Empty;

        [Range(1, 100000000000000, ErrorMessage = "El precio debe ser mayor a 0")]
        public decimal Precio { get; set; }

        [Required(ErrorMessage = "La direccion es necesaria.")]
        [StringLength(100, ErrorMessage = "La cantidad maxima de caracteres para la direccion son 100")]
        public string Direccion { get; set; } = string.Empty;

        [Required(ErrorMessage = "La ciudad es necesaria.")]
        [StringLength(100, ErrorMessage = "La cantidad maxima de caracteres para la ciudad son 100")]
        public string Ciudad { get; set; } = string.Empty;

        [Range(1, 10000, ErrorMessage = "Metros cuadrados invalidos")]
        public int MetrosCuadrados { get; set; }

        [Range(0, 20, ErrorMessage = " Cantidad de habitaciones invalida")]
        public int Habitaciones { get; set; }

        [Range(0, 20, ErrorMessage = "Cantidad de baños invalida")]
        public int Banos { get; set; }

        [Required(ErrorMessage = "El estado es necesario.")]
        [RegularExpression("Disponible|Reservada|Vendida|Alquilada", ErrorMessage = "El estado debe ser Disponible, Reservada, Vendida o Alquilada")]
        public string Estado { get; set; } = string.Empty;
    }
}
