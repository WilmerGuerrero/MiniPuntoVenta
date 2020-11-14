using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Producto
    {

        public int Id { get; set; }
        public string Nombre { get; set; }
        public int InventarioID { get; set; }
        public PuntoVenta PuntoVenta{ get; set; }

        public List<ProductoFacturado> facturacion { get; set; }

        public class mapear
        {
            public mapear(EntityTypeBuilder<Producto> mapeo)
            {
                mapeo.HasKey(x => x.Id);
                mapeo.Property(x => x.Id).HasColumnName("Id");
                mapeo.Property(x => x.Nombre).HasColumnName("Nombre");
                mapeo.Property(x => x.InventarioID).HasColumnName("InventarioID").IsRequired();
                mapeo.HasOne(x=>x.PuntoVenta).WithMany(x=>x.Productos);
                mapeo.HasMany(x => x.facturacion).WithOne(x => x.producto);
            }
        }
    }
}
