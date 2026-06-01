namespace Inmo.Dominio.Entidades
{
    public class ContratoCliente
    {
        public int Id { get; set; }
        public int ContratoId { get; set; }
        public Contrato? Contrato { get; set; }

        public int ClienteId { get; set; }
        public Cliente? Cliente { get; set; }

        public string Rol {  get; set; } = string.Empty;
    }
}
