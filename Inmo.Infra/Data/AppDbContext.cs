using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Inmo.Dominio.Entidades;

namespace Inmo.Infra.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Propiedad> Propiedades { get; set; }
        public DbSet<Cita> Citas { get; set; }
        public DbSet<Contrato> Contratos { get; set; }
        public DbSet<ContratoCliente> ContratoClientes { get; set; }
        public DbSet<Factura> Facturas { get; set; }
        public DbSet<Pago> Pagos { get; set; }
        public DbSet<PropiedadImagen> PropiedadImagenes { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Propiedad>()
                .Property(p => p.Precio)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Contrato>()
            .Property(p => p.PrecioBase)
            .HasPrecision(18, 2);

            modelBuilder.Entity<Contrato>()
            .Property(p => p.MontoFinal)
            .HasPrecision(18, 2);

            modelBuilder.Entity<Factura>()
            .Property(p => p.Importe)
            .HasPrecision(18, 2);

            modelBuilder.Entity<Pago>()
            .Property(p => p.ImportePagado)
            .HasPrecision(18, 2);

            modelBuilder.Entity<ContratoCliente>()
            .HasOne(cc => cc.Contrato)
            .WithMany(c => c.ContratoClientes)
            .HasForeignKey(cc => cc.ContratoId);

            modelBuilder.Entity<ContratoCliente>()
            .HasOne(cc => cc.Cliente)
            .WithMany(c => c.ContratoClientes)
            .HasForeignKey(cc => cc.ClienteId);

            //cambio por el cambio en la relacion factura y pagos. queda de 1 a muchos
            modelBuilder.Entity<Pago>()
            .HasOne(p => p.Factura)
            .WithMany(f => f.Pagos)
            .HasForeignKey(p => p.FacturaId);

            modelBuilder.Entity<Cita>()
            .HasOne(c => c.Cliente)
            .WithMany(c => c.Citas)
            .HasForeignKey(c => c.ClienteId);

            modelBuilder.Entity<Cita>()
            .HasOne(c => c.Propiedad)
            .WithMany(p => p.Citas)
            .HasForeignKey(c => c.PropiedadId);

            // relacion por el cambio en la forma de guardar imagenes
            modelBuilder.Entity<PropiedadImagen>()
            .HasOne(pi => pi.Propiedad)
            .WithMany(p => p.Imagenes)
            .HasForeignKey(pi => pi.PropiedadId)
            .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
