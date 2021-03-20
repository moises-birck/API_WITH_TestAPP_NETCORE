
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace APIs.test
{
    public class API_1_Test
    {
        
        private readonly TestServer _server1;
        private readonly HttpClient _client1;
        
        public API_1_Test()
        {
            // Arrange
            _server1 = new TestServer(new WebHostBuilder()
               .UseStartup<API__1.Startup>());
            _client1 = _server1.CreateClient();            
        }

        [Fact]
        public async Task TaxaJuros()
        {
            // Act
            var response = await _client1.GetAsync("/taxaJuros");
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            
            // Assert
            Assert.Equal("0,01", responseString);
        }

        [Fact]
        public async Task TaxaJurosPercentual()
        {
            // Act
            var response = await _client1.GetAsync("/taxaJurosPercentual");
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.Equal("1%", responseString);
        }

        
    }
}
