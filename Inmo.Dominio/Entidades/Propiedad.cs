namespace Inmo.Dominio.Entidades
{
    public class Propiedad
    {
        public int Id {  get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public string Tipo { get; set; } = string.Empty;
        public string Operacion { get; set; } = string.Empty;
        public decimal Precio { get; set; }
        public string Direccion { get; set; } = string.Empty;
        public string Ciudad { get; set; } = string.Empty;
        public int MetrosCuadrados { get; set; }
        public int Habitaciones { get; set; }
        public int Banos { get; set; }
        public string Estado { get; set; } = string.Empty;

        public List<PropiedadImagen> Imagenes { get; set; } = new();

        public List<Cita> Citas { get; set; } = new();

    }
}
