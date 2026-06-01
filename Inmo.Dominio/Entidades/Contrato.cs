namespace Inmo.Dominio.Entidades
{
    public class Contrato
    {
        public int Id {  get; set; }

        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin  { get; set; }
        public int PropiedadId { get; set; }
        public Propiedad? Propiedad { get; set; }
        public decimal PrecioBase { get; set; }
        public decimal MontoFinal { get; set; }
        public string TipoContrato { get; set; } = string.Empty;
        public List<ContratoCliente>? ContratoClientes { get; set; }

    }
}
