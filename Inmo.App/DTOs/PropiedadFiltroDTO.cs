namespace Inmo.App.DTOs
{
    public class PropiedadFiltroDTO
    {
        public string? Ciudad {  get; set; }
        public string? Tipo { get; set; }
        public string? Operacion { get; set; }
        public decimal? PrecioMin { get; set; }
        public decimal? PrecioMax { get; set; }

        public int? Habitaciones { get; set; }

    }
}
