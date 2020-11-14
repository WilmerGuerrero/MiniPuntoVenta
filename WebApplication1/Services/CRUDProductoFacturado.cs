using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class CRUDProductoFacturado
    {
        private readonly PuntoVentadbContext _context;

        public CRUDProductoFacturado(PuntoVentadbContext context)
        {
            _context = context;
        }

        public List<ProductoFacturado> getProductoFacturados()
        {
            var resultado = _context.procesoFactura.ToList();

            return resultado;
        }
        public ProductoFacturado getProductoFacturadoPorFactura(int id)
        {
            var resultado = _context.procesoFactura.Where(x => x.FacturaId == id).FirstOrDefault();

            return resultado;
        }
        public ProductoFacturado getProductoFacturadoPorProducto(int id)
        {
            var resultado = _context.procesoFactura.Where(x => x.productoId == id).FirstOrDefault();

            return resultado;
        }

        public async Task<bool> AddProductoFacturado(ProductoFacturado ProductoFacturado)
        {
            try
            {
                if (ProductoFacturado != null)
                    await _context.AddAsync(ProductoFacturado);
                _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
       
    }
}
