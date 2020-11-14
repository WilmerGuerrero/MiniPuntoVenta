using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Factura
    {
        public int Id { get; set; }
        public List<ProductoFacturado> facturacion{ get; set; }

        public class mapear
        {
            public mapear(EntityTypeBuilder<Factura> mapeo)
            {
                mapeo.HasKey(x => x.Id);
                mapeo.Property(x => x.Id).HasColumnName("Id");
                mapeo.HasMany(x => x.facturacion).WithOne(x => x.factura);
            }
        }
    }

   
}
