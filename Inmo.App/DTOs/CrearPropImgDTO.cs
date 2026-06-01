using System.ComponentModel.DataAnnotations;

namespace Inmo.App.DTOs
{
    public class CrearPropImgDTO
    {
        [Range(1, 1000, ErrorMessage = "El id no es correcto")]
        public int PropiedadId { get; set; }

        [Required(ErrorMessage ="La url de la imagen es necesaria")]
        [StringLength(2048, ErrorMessage ="La cantidad maxima de caracteres para la url son 2048")]
        public string Url { get; set; } = string.Empty;
    }
}
