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
    public class ProductosController : ControllerBase
    {
        private readonly CRUDproductos _service;

        public ProductosController(CRUDproductos service)
        {
            _service = service;
        }
        [HttpGet]
        [Route("obtener-productos")]
        public async Task<IActionResult> getProductos()
        {
            var lista = _service.getProductos();
            if (lista != null)
            {
                return Ok(lista);
            }
            else
            {
                return BadRequest();
            }

        }

        [HttpGet]
        [Route("obtener-productos/{id}")]
        public async Task<IActionResult> getProductosPorId(int id)
        {
            var resultado =  _service.getProducto(id);
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
        [Route("agregar-producto")]
        public async Task<IActionResult> AddProducto([FromBody] Producto Producto)
        {
            var agregar =_service.AddProducto(Producto);
            if (agregar)
            {
                return Ok(agregar);
            }
            else
            {
                return BadRequest();
            }

        }

    }
}
