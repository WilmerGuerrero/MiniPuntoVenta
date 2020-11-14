using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class ProductoFacturado
    {
        public int productoId { get; set; }
        public int FacturaId { get; set; }

        public int ClienteId { get; set; }
        public Producto producto { get; set; }
        public Factura factura { get; set; }
        public Cliente cliente { get; set; }

        public class mapear
        {
            public mapear(EntityTypeBuilder<ProductoFacturado> mapeo)
            {
                mapeo.HasKey(x => new { x.FacturaId, x.productoId, x.ClienteId });
                mapeo.HasOne(x => x.factura).WithMany(x => x.facturacion);
                mapeo.HasOne(x => x.cliente).WithMany(x => x.facturacion);
                mapeo.HasOne(x => x.producto).WithMany(x => x.facturacion);
                mapeo.Property(x =>x.productoId).HasColumnName("Productoid");
                mapeo.Property(x =>x.FacturaId).HasColumnName("Facturaid");
                mapeo.Property(x =>x.ClienteId).HasColumnName("Clienteid");
            }
        }
    }
}
