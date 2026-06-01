namespace Inmo.Dominio.Entidades
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public int DNI { get; set; } 
        public string Email { get; set; } = string.Empty;
        public string Telefono { get; set;} = string.Empty; // string porque si usamos int no podriamos poner 0 a la izquierda, guiones, etc
        public string TipoCliente {  get; set; } = string.Empty;
        public List<ContratoCliente> ContratoClientes { get; set; } = new();
        public List<Cita> Citas { get; set; } = new();
    }
}
