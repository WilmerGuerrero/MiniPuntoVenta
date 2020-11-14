using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class CRUDcliente
    {
        private readonly PuntoVentadbContext _context;

        public CRUDcliente(PuntoVentadbContext context)
        {
            _context = context;
        }

        public List<Cliente> getClientes()
        {
            var resultado =  _context.Cliente.ToList();

            return resultado;
        }
        public Cliente getCliente(int id)
        {
            var resultado = _context.Cliente.Where(x=>x.id==id).FirstOrDefault();

            return resultado;
        }


        public async Task<bool> AddCliente(Cliente cliente)
        {
            try
            {
                if(cliente!=null)
                await _context.AddAsync(cliente);
                _context.SaveChanges();

                return true;
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public bool UpdateCliente(Cliente cliente,int id)
        {
          
            try
                {
                if (cliente != null)
                {
                    var respuesta = _context.Cliente.Where(x => x.id == id).FirstOrDefault();
                    respuesta.nombre = cliente.nombre;
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

        }
        

        public bool DeleteCliente(int id)
        {
            try
            {   
                var resultado = _context.Cliente.Where(x => x.id == id).FirstOrDefault();
                _context.Cliente.Remove(resultado);
                return true;
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

    }   
}
