using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoFacturadoController : ControllerBase
    {
        private readonly CRUDProductoFacturado _service;
        public ProductoFacturadoController(CRUDProductoFacturado service)
        {
            _service=service;
        }
        [HttpGet]
        [Route("obtener-productos-facturados")]
        public async Task<IActionResult> obtenerProductosFacturados()
        {
            var resultado = _service.getProductoFacturados();
            if (resultado != null)
            {
                return Ok(resultado);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("obtener-producto-facturado-Porfactura/{id}")]
        public async Task<IActionResult> obtenerProductosFacturadosPorFactura(int id)
        {
            var resultado = _service.getProductoFacturadoPorFactura(id);
            if (resultado != null)
            {
                return Ok(resultado);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("obtener-producto-facturado-Porproducto/{id}")]
        public async Task<IActionResult> obtenerProductosFacturadosPorProducto(int id)
        {
            var resultado = _service.getProductoFacturadoPorProducto(id);
            if (resultado != null)
            {
                return Ok(resultado);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("agregar-producto-facturado")]
        public async Task<IActionResult> agregarProductosFacturado([FromBody] ProductoFacturado factura)
        {
            var resultado = _service.AddProductoFacturado(factura);
            if (await resultado)
            {
                return Ok(resultado);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
