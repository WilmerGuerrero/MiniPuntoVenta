using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PuntoVentaController: ControllerBase
    {
        private readonly CRUDPuntoVenta _service;

        public PuntoVentaController(CRUDPuntoVenta service)
        {
            _service = service;
        }
        [HttpGet]
        [Route("obtener-punto")]
        public async Task<IActionResult> getPuntoVenta()
        {
            var lista = _service.getPuntoVentas();
            if (lista != null)
            {
                return Ok(lista);
            }
            else
            {
                return BadRequest();
            }
            
        }

        [HttpPost]
        [Route("agregar-punto")]
        public async Task<IActionResult> AddPuntoVenta([FromBody] PuntoVenta puntoVenta)
        {
            var agregar = _service.AddPuntoVenta(puntoVenta);
            if (agregar != null)
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
