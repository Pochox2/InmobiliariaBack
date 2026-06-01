using System.ComponentModel.DataAnnotations;


namespace Inmo.App.DTOs
{
    public class UpdatePropImgDTO

    {
        [Required(ErrorMessage = "El id de la propiedad es necesario")]
        public int Id { get; set; }

        [Required(ErrorMessage = "La url de la imagen es necesaria")]
        [StringLength(100, ErrorMessage = "La cantidad maxima de caracteres para la url son 100")]
        public string Url { get; set; } = string.Empty;
    }
}
