using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Cliente
    {
        public int id { get; set; }
        public string nombre { get; set; }

        public List<ProductoFacturado> facturacion {get;set;}

        public class mapear
        {
            public mapear(EntityTypeBuilder<Cliente> mapeo)
            {
                mapeo.HasKey(x=>x.id);
                mapeo.Property(x => x.id).HasColumnName("Id").UseIdentityColumn();
                mapeo.Property(x => x.nombre).HasColumnName("Nombre");
                mapeo.HasMany(x => x.facturacion).WithOne(x => x.cliente);
            }
        }
    }
}
