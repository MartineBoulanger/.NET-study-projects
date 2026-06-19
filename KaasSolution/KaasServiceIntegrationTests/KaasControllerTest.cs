using KaasService.Repositories;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using Moq;
using System.Threading.Tasks;
using System.Net.Http;
using Microsoft.Extensions.DependencyInjection;
using KaasService.Models;
using System.Text.Json;
using KaasService.Controllers;
using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore.Builder;

namespace KaasServiceIntegrationTests
{
    [TestClass]
    public sealed class KaasControllerTest
    {
        HttpClient client = null!;
        Mock<IKaasRepository> mock = null!;

        [TestInitialize]
        public void TestInitialize()
        {
            mock = new Mock<IKaasRepository>();
            var repository = mock.Object;
            var factory = new WebApplicationFactory<KaasController>();
            client = factory.WithWebHostBuilder(builder =>
            builder.ConfigureTestServices(services =>
            services.AddTransient<IKaasRepository>(_ => repository)))
            .CreateClient();
        }

        [TestMethod]
        public async Task GetMetOnbestaandeKaasGeeftNotFound()
        {
            var response = await client.GetAsync("kazen/1");
            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
            mock.Verify(repo => repo.FindByIdAsync(1));
        }

        [TestMethod]
        public async Task GetMetBestaandeKaasGeeftOK()
        {
            mock.Setup(repo => repo.FindByIdAsync(1)).Returns(Task.FromResult<Kaas?>(
            new Kaas() { Id = 1, Naam = "1", Soort = "1", Smaak = "1" }));
            var response = await client.GetAsync("kazen/1");
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            mock.Verify(repo => repo.FindByIdAsync(1));
            var body = await response.Content.ReadAsStringAsync();
            var bodyInJson = JsonDocument.Parse(body);
            Assert.AreEqual(1, bodyInJson.RootElement.GetProperty("id").GetInt32());
            Assert.AreEqual("1", bodyInJson.RootElement.GetProperty("naam").GetString());
        }
    }
}
