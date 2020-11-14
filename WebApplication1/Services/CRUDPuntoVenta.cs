using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class CRUDPuntoVenta
    {
        private readonly PuntoVentadbContext _context;

        public CRUDPuntoVenta(PuntoVentadbContext context)
        {
            _context = context;
        }

        public List<PuntoVenta> getPuntoVentas()
        {
            var resultado = _context.PuntoVenta.Include(x => x.Productos).ToList();

            return resultado;
        }
        public PuntoVenta getPuntoVenta(int id)
        {
            var resultado = _context.PuntoVenta.Include(x => x.Productos).Where(x => x.Id == id).FirstOrDefault();

            return resultado;
        }


        public async Task<bool> AddPuntoVenta(PuntoVenta PuntoVenta)
        {
            try
            {
                if (PuntoVenta != null)
                    await _context.AddAsync(PuntoVenta);
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
