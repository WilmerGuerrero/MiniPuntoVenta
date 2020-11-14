using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class PuntoVentadbContext:DbContext
    {
        public PuntoVentadbContext()
        {

        }
        public PuntoVentadbContext(DbContextOptions options):base(options)
        {

        }

        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Producto> Producto { get; set; }
        public DbSet<Factura> Factura { get; set; }
        public DbSet<PuntoVenta> PuntoVenta { get; set; }
        public DbSet<ProductoFacturado> procesoFactura { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {

        }

        protected override void OnModelCreating(ModelBuilder crear)
        {
            new Cliente.mapear(crear.Entity<Cliente>());
            new Producto.mapear(crear.Entity<Producto>());
            new Factura.mapear(crear.Entity<Factura>());
            new PuntoVenta.mapear(crear.Entity<PuntoVenta>());
            new ProductoFacturado.mapear(crear.Entity<ProductoFacturado>());
        }
    }
}
