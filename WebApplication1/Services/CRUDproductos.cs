using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class CRUDproductos
    {
        private readonly PuntoVentadbContext _context;

        public CRUDproductos(PuntoVentadbContext context)
        {
            _context = context;
        }

        public List<Producto> getProductos()
        {
            var resultado = _context.Producto.ToList();

            return resultado;
        }
        public Producto getProducto(int id)
        {
            var resultado = _context.Producto.Where(x => x.Id == id).FirstOrDefault();

            return resultado;
        }


        public bool AddProducto(Producto Producto)
        {
            try
            {
                if (Producto != null)
                 _context.Producto.Add(Producto);
                _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public bool UpdateProducto(Producto Producto, int id)
        {

            try
            {
                if (Producto != null)
                {
                    var respuesta = _context.Producto.Where(x => x.Id == id).FirstOrDefault();
                    respuesta.Nombre = Producto.Nombre;
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

        }


        public bool DeleteProducto(int id)
        {
            try
            {
                var resultado = _context.Producto.Where(x => x.Id == id).FirstOrDefault();
                _context.Producto.Remove(resultado);
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
