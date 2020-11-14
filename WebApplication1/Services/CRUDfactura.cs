using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class CRUDfactura
    {
        private readonly PuntoVentadbContext _context;

        public CRUDfactura(PuntoVentadbContext context)
        {
            _context = context;
        }

        public List<Factura> getFacturas()
        {
            var resultado = _context.Factura.Include(x=>x.facturacion).ToList();

            return resultado;
        }
        public Factura getFactura(int id)
        {
            var resultado = _context.Factura.Include(x=>x.facturacion).Where(x => x.Id == id).FirstOrDefault();

            return resultado;
        }


        public async Task<bool> AddFactura(Factura Factura)
        {
            try
            {
                if (Factura != null)
                    await _context.AddAsync(Factura);
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
