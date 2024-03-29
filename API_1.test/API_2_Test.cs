﻿using API__2;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace APIs.test
{
    public class API_2_Test
    {
        private readonly TestServer _server1;
        private readonly HttpClient _client1;

        public API_2_Test()
        {
            // Arrange
            _server1 = new TestServer(new WebHostBuilder()
               .UseStartup<API__2.Startup>());
            _client1 = _server1.CreateClient();
        }

        [Fact]
        public async Task CalculaJuros()
        {
            // Act
            var response = await _client1.GetAsync("/CalculaJuros?valorInicial=100&meses=5");
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.Equal("105,10", responseString);
        }

        [Fact]
        public async Task ShowMeTheCode()
        {
            // Act
            var response = await _client1.GetAsync("/ShowMeTheCode");
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.Equal("https://github.com/sesiom12/API_WITH_TDD_NETCORE", responseString);
        }


    }
}