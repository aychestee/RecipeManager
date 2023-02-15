using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using Xunit;

namespace RecipeManager.Tests
{
    public class WebTests : IDisposable
    {
        protected TestServer _testServer;

        public WebTests()
        {
            var webBuilder = new WebHostBuilder();
            webBuilder.UseStartup<Startup>();
            _testServer = new TestServer(webBuilder);
        }

        [Fact]
        public async Task TestGetIndexAsync()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "/");
            var client = _testServer.CreateClient();
            var response = await client.SendAsync(request);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task TestGetIndexContentAsync()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "/");
            var client = _testServer.CreateClient();
            var response = await client.GetAsync("/");
            var stringResponse = await response.Content.ReadAsStringAsync();
            Assert.Contains("My Recipes", stringResponse);
        }

        public void Dispose() 
        { 
            _testServer.Dispose();
        }
    }
}