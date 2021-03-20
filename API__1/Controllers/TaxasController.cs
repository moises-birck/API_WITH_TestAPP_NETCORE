using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API__1.Controllers
{
    [ApiController]
    public class TaxasController : ControllerBase
    {
        public static double juros = 0.01;
        
        [Route("/taxaJuros")]
        [HttpGet]
        public string taxaJuros()
        {
            return juros.ToString();
        }

        [Route("/taxaJurosPercentual")]
        [HttpGet]
        public string taxaJurosPercentual()
        {
            return $"{juros * 100}%";
        }
    }
}
