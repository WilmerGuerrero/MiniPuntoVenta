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
    public class FacturaController : ControllerBase
    {
        private readonly CRUDfactura _service;

        public FacturaController(CRUDfactura service)
        {
            _service = service;
        }
        [HttpGet]
        [Route("/obtener-Factura/")]
        public async Task<IActionResult> getFacturas()
        {
            var lista = _service.getFacturas();
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
        [Route("/obtener-Factura/{id}")]
        public async Task<IActionResult> getFactura(int id)
        {
            var resultado = _service.getFactura(id);
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
        [Route("/agregar-Factura/")]
        public async Task<IActionResult> AddFactura([FromBody] Factura Factura)
        {
            var agregar = await _service.AddFactura(Factura);
            if (agregar != true)
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
