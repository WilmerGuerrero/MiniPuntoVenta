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
    public class ClienteController : ControllerBase
    {
        private readonly CRUDcliente _service;

        public ClienteController(CRUDcliente service)
        {
            _service = service;
        }
        [HttpGet]
        [Route("/obtener-cliente/")]
        public async Task<IActionResult> getClientes()
        {
            var lista = _service.getClientes();
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
        [Route("/obtener-cliente/{id}")]
        public async Task<IActionResult> getCliente(int id)
        {
            var resultado = _service.getCliente(id);
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
        [Route("agregar-cliente")]
        public async Task<IActionResult> AddCliente([FromBody] Cliente Cliente)
        {
            var agregar = await _service.AddCliente(Cliente);
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
