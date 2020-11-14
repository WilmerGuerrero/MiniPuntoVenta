using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class PuntoVenta
    {

        public int Id { get; set; }
        public int Stock { get; set; }
        public List<Producto> Productos { get; set; }

        public class mapear
        {
            public mapear(EntityTypeBuilder<PuntoVenta> mapeo)
            {
                mapeo.HasKey(x => x.Id);
                mapeo.Property(x => x.Id).HasColumnName("Id");
                mapeo.Property(x => x.Stock).HasColumnName("Stock");
                mapeo.HasMany(x=>x.Productos).WithOne(x => x.PuntoVenta);
            }
        }
    }

}
