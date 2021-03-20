using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.TestHost;
using RestSharp;
using System;
using System.Net;
using System.Net.Http;

namespace API__2.Controllers
{
    [ApiController]
    public class CalculaJurosController : ControllerBase
    {

        private readonly TestServer _server1;
        private readonly HttpClient _client1;

        [HttpGet]
        [Route("/CalculaJuros")]
        public string CalculaJuros(decimal valorInicial, int meses)
        {
            try
            {
                double taxaJuros = 0;

                var API_1_url = "https://localhost:44361/taxaJuros";
                
                using (var client = new HttpClient())
                {
                    using (var response = client.GetAsync(API_1_url).Result)
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            var content = response.Content.ReadAsStringAsync();
                            taxaJuros = Convert.ToDouble(content.Result);                                
                        }
                        else
                        {
                            throw new Exception("Erro ao consultar API_1");
                        }
                    }
                }

                //SOMENTE PARA EXECUTAR O TESTE, CASO A API_1, não esteja rodando.
                //OBS: tem q add referencia dá API_1
                //    TestServer _server1 = new TestServer(new WebHostBuilder()
                //                    .UseStartup<API__1.Startup>());
                //    HttpClient _client1 = _server1.CreateClient();

                //    var response = _client1.GetAsync("/taxaJuros").Result;
                //    if (response.IsSuccessStatusCode)
                //    {
                //        var content2 = response.Content.ReadAsStringAsync();
                //        taxaJuros = Convert.ToDouble(content2.Result);
                //    }
                //    else
                //    {
                //        throw new Exception("Erro ao criar e consultar API_1");
                //    }

                taxaJuros = 1 + taxaJuros;
                decimal potencia = Convert.ToDecimal(Math.Pow(taxaJuros, Convert.ToDouble(meses)));
                var calculo = valorInicial * potencia;
                return calculo.ToString("0.00");
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            
        }
    }
}
