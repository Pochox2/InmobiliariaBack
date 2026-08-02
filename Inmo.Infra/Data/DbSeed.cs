using Inmo.Dominio.Entidades;
using System.Linq;

namespace Inmo.Infra.Data
{
    public static class DbSeeder
    {
        public static void Seed(AppDbContext context)
        {

            if (context.Clientes.Any() ||
                context.Propiedades.Any())
                return;

            var clientes = new List<Cliente>
            {
                new Cliente
                {      
                    Nombre = "Juan",
                    Apellido = "Pérez",
                    DNI = 35123456,
                    Email = "juan.perez@email.com",
                    Telefono = "3364123456",
                    TipoCliente = "Comprador"
                },

                new Cliente
                {
                    Nombre = "María",
                    Apellido = "González",
                    DNI = 28765432,
                    Email = "maria.gonzalez@email.com",
                    Telefono = "3364987654",
                    TipoCliente = "Propietario"
                 },

                new Cliente
                {
                    Nombre = "Carlos",
                    Apellido = "Rodríguez",
                    DNI = 32987654,
                    Email = "carlos.rodriguez@email.com",
                    Telefono = "3364556677",
                    TipoCliente = "Inquilino"
                },

                new Cliente
                {
                    Nombre = "Ana",
                    Apellido = "Fernández",
                    DNI = 30111222,
                    Email = "ana.fernandez@email.com",
                    Telefono = "3364778899",
                    TipoCliente = "Vendedor"
                }
             };

            context.Clientes.AddRange(clientes);
            context.SaveChanges();

            var propiedades = new List<Propiedad>
{
                new Propiedad
                {
                    Titulo = "Casa moderna en San Nicolás",
                    Descripcion = "Casa de 3 dormitorios con patio y cochera.",
                    Tipo = "Casa",
                    Operacion = "Venta",
                    Precio = 185000,
                    Direccion = "Mitre 123",
                    Ciudad = "San Nicolás",
                    MetrosCuadrados = 160,
                    Habitaciones = 3,
                    Banos = 2,
                    Estado = "Disponible"
                },

                new Propiedad
                {
                    Titulo = "Departamento céntrico",
                    Descripcion = "Departamento de 2 ambientes totalmente equipado.",
                    Tipo = "Departamento",
                    Operacion = "Alquiler",
                    Precio = 650000,
                    Direccion = "Pellegrini 456",
                    Ciudad = "Rosario",
                    MetrosCuadrados = 58,
                    Habitaciones = 2,
                    Banos = 1,
                    Estado = "Disponible"
                },

                new Propiedad
                {
                    Titulo = "Local comercial",
                    Descripcion = "Excelente ubicación sobre avenida principal.",
                    Tipo = "Local",
                    Operacion = "Alquiler",
                    Precio = 980000,
                    Direccion = "Av. Savio 850",
                    Ciudad = "San Nicolás",
                    MetrosCuadrados = 95,
                    Habitaciones = 1,
                    Banos = 1,
                    Estado = "Reservada"
                },

                new Propiedad
                {
                    Titulo = "Casa con jardín",
                    Descripcion = "Ideal para familia. Amplio parque y parrilla.",
                    Tipo = "Casa",
                    Operacion = "Venta",
                    Precio = 220000,
                    Direccion = "Belgrano 980",
                    Ciudad = "Ramallo",
                    MetrosCuadrados = 210,
                    Habitaciones = 4,
                    Banos = 3,
                    Estado = "Disponible"
                }
            };

            context.Propiedades.AddRange(propiedades);
            context.SaveChanges();

            var imagenes = new List<PropiedadImagen>
            {
                new PropiedadImagen
                {
                    PropiedadId = propiedades[0].Id,
                    Url = "https://images.unsplash.com/photo-1564013799919-ab600027ffc6?w=1200"
                },
                new PropiedadImagen
                {
                    PropiedadId = propiedades[0].Id,
                    Url = "https://images.unsplash.com/photo-1570129477492-45c003edd2be?w=1200"
                },

                new PropiedadImagen
                {
                    PropiedadId = propiedades[1].Id,
                    Url = "https://images.unsplash.com/photo-1502672260266-1c1ef2d93688?w=1200"
                },
                new PropiedadImagen
                {
                    PropiedadId = propiedades[1].Id,
                    Url = "https://images.unsplash.com/photo-1484154218962-a197022b5858?w=1200"
                },

                new PropiedadImagen
                {
                    PropiedadId = propiedades[2].Id,
                    Url = "https://images.unsplash.com/photo-1497366754035-f200968a6e72?w=1200"
                },
                new PropiedadImagen
                {
                    PropiedadId = propiedades[2].Id,
                    Url = "https://images.unsplash.com/photo-1497366412874-3415097a27e7?w=1200"
                },

                new PropiedadImagen
                {
                    PropiedadId = propiedades[3].Id,
                    Url = "https://images.unsplash.com/photo-1600585154526-990dced4db0d?w=1200"
                },
                new PropiedadImagen
                {
                    PropiedadId = propiedades[3].Id,
                    Url = "https://images.unsplash.com/photo-1600607687939-ce8a6c25118c?w=1200"
                }
            };

            context.PropiedadImagenes.AddRange(imagenes);
            context.SaveChanges();

            var contratos = new List<Contrato>
            {
                new Contrato
                {
                    FechaInicio = new DateTime(2026, 1, 15),
                    FechaFin = new DateTime(2026, 1, 15),
                    PropiedadId = propiedades[0].Id,
                    PrecioBase = 185000,
                    MontoFinal = 180000,
                    TipoContrato = "Venta"
                },

                new Contrato
                {
                    FechaInicio = new DateTime(2026, 2, 1),
                    FechaFin = new DateTime(2027, 2, 1),
                    PropiedadId = propiedades[1].Id,
                    PrecioBase = 650000,
                    MontoFinal = 650000,
                    TipoContrato = "Alquiler"
                }
            };

            context.Contratos.AddRange(contratos);
            context.SaveChanges();

            var contratoClientes = new List<ContratoCliente>
            {
                new ContratoCliente
                {
                    ContratoId = contratos[0].Id,
                    ClienteId = clientes[0].Id,
                    Rol = "Comprador"
                },

                new ContratoCliente
                {
                    ContratoId = contratos[0].Id,
                    ClienteId = clientes[1].Id,
                    Rol = "Vendedor"
                },

                new ContratoCliente
                {
                    ContratoId = contratos[1].Id,
                    ClienteId = clientes[2].Id,
                    Rol = "Inquilino"
                },

                new ContratoCliente
                {
                    ContratoId = contratos[1].Id,
                    ClienteId = clientes[1].Id,
                    Rol = "Propietario"
                }
            };

            context.ContratoClientes.AddRange(contratoClientes);
            context.SaveChanges();

            var citas = new List<Cita>
            {
                new Cita
                {
                    ClienteId = clientes[0].Id,
                    PropiedadId = propiedades[0].Id,
                    FechaHora = DateTime.Now.AddDays(2),
                    Estado = "Agendada"
                },

                new Cita
                {
                    ClienteId = clientes[2].Id,
                    PropiedadId = propiedades[1].Id,
                    FechaHora = DateTime.Now.AddDays(-3),
                    Estado = "Realizada"
                },

                new Cita
                {
                    ClienteId = clientes[0].Id,
                    PropiedadId = propiedades[3].Id,
                    FechaHora = DateTime.Now.AddDays(5),
                    Estado = "Pospuesta"
                },

                new Cita
                {
                    ClienteId = clientes[2].Id,
                    PropiedadId = propiedades[2].Id,
                    FechaHora = DateTime.Now.AddDays(-1),
                    Estado = "Cancelada"
                }
            };

            context.Citas.AddRange(citas);
            context.SaveChanges();

            var facturas = new List<Factura>
            {
                new Factura
                {
                    NroFactura = "FAC-0001",
                    TipoFactura = "A",
                    ClienteId = clientes[0].Id,
                    FechaEmision = DateTime.Now.AddDays(-15),
                    FechaVencimiento = DateTime.Now.AddDays(15),
                    Estado = "Pagada",
                    Importe = 180000,
                    Operacion = "Venta"
                },

                new Factura
                {
                    NroFactura = "FAC-0002",
                    TipoFactura = "B",
                    ClienteId = clientes[2].Id,
                    FechaEmision = DateTime.Now.AddDays(-5),
                    FechaVencimiento = DateTime.Now.AddDays(5),
                    Estado = "Pendiente",
                    Importe = 650000,
                    Operacion = "Alquiler"
                },

                new Factura
                {
                    NroFactura = "FAC-0003",
                    TipoFactura = "B",
                    ClienteId = clientes[1].Id,
                    FechaEmision = DateTime.Now.AddDays(-40),
                    FechaVencimiento = DateTime.Now.AddDays(-10),
                    Estado = "Pagada",
                    Importe = 980000,
                    Operacion = "Alquiler"
                }
            };

            context.Facturas.AddRange(facturas);
            context.SaveChanges();

            var pagos = new List<Pago>
            {
                new Pago
                {
                    FacturaId = facturas[0].Id,
                    FechaPago = DateTime.Now.AddDays(-10),
                    ImportePagado = 180000m,
                    MetodoPago = "Transferencia"
                },

                new Pago
                {
                    FacturaId = facturas[1].Id,
                    FechaPago = DateTime.Now.AddDays(-2),
                    ImportePagado = 300000m,
                    MetodoPago = "Tarjeta"
                },

                new Pago
                {
                    FacturaId = facturas[2].Id,
                    FechaPago = DateTime.Now.AddDays(-20),
                    ImportePagado = 980000m,
                    MetodoPago = "Efectivo"
                }
            };

            context.Pagos.AddRange(pagos);
            context.SaveChanges();
        }
    }
}