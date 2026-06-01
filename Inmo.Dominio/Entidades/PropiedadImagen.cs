namespace Inmo.Dominio.Entidades
{
    public class PropiedadImagen
    {
        public int Id { get; set; }
        public int PropiedadId { get; set; }
        public string Url { get; set; } = string.Empty;

        public Propiedad? Propiedad { get; set; }
    }
}
