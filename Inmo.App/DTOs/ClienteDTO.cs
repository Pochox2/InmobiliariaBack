namespace Inmo.App.DTOs
{
    public class ClienteDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public int DNI { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string TipoCliente { get; set; } = string.Empty;
        public List<CitaDTO> Citas { get; set; } = new();
        public List<ContratoClienteDTO> Contratos { get; set; } = new();
    }
}
