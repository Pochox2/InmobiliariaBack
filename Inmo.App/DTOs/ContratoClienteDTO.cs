    namespace Inmo.App.DTOs
{
    public class ContratoClienteDTO
    {
        public int Id { get; set; }

        public int ContratoId { get; set; }

        public int ClienteId { get; set; }

        public string Rol { get; set; } = string.Empty;

        public string ClienteNombre {  get; set; } = string.Empty;

        public string TipoContrato { get; set; } = string.Empty;
    }
}
