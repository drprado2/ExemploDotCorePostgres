using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TestePostgres.Data;
using TestePostgres.Entities;

namespace TestePostgres.Controllers
{
    [Route("clientes")]
    public class ClienteController : Controller
    {
        private static int Id = 0;
        [HttpGet]
        [Route("/")]
        public IActionResult Get([FromServices]MyDbContext context)
        {
            // Exemplo de persistencia
            context.Clients.Add(new Client() {Id = ++Id, Name = "Pedro", Age = 25});
            context.SaveChanges();
            return Ok("Funcionou");
        }

        [HttpGet]
        [Route("/teste")]
        public IActionResult GetDois([FromServices]MyDbContext context)
        {
            // Exemplo obtendo os dados
            var clientes = context.Clients.ToList();

            return Ok(clientes);
        }
    }
}
