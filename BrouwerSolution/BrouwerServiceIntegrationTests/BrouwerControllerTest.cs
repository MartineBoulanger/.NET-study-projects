using BrouwerService.Controllers;
using BrouwerService.Models;
using BrouwerService.Repositories;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System.Net;
using System.Text.Json;

namespace BrouwerServiceIntegrationTests;

[TestClass]
public class BrouwerControllerTest
{
    HttpClient client = null!;
    Mock<IBrouwerRepository> mock = null!;
    Brouwer brouwer1 = null!;

    [TestInitialize]
    public void TestInitialize()
    {
        mock = new Mock<IBrouwerRepository>();
        var repository = mock.Object;
        var factory = new WebApplicationFactory<BrouwerController>();
        client = factory.WithWebHostBuilder(builder => builder.ConfigureTestServices(services => services.AddScoped<IBrouwerRepository>(_ => repository))).CreateClient();
        brouwer1 = new Brouwer { Id = 1, Naam = "1", Postcode = 1000, Gemeente = "1" };
    }

    [TestMethod]
    public async Task DeleteMetBestaandeBrouwerGeeftOK()
    {
        mock.Setup(repo => repo.FindByIdAsync(1)).Returns(Task.FromResult((Brouwer?)brouwer1));
        var response = await client.DeleteAsync("brouwers/1");
        Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        mock.Verify(repo => repo.DeleteAsync(brouwer1));
    }

    [TestMethod]
    public async Task DeleteMetOnbestaandeBrouwerGeeftNotFound()
    {
        var response = await client.DeleteAsync("brouwers/-1");
        Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
        mock.Verify(repo => repo.DeleteAsync(It.IsAny<Brouwer>()), Times.Never);
    }

    [TestMethod]
    public async Task GetMetOnbestaandeBrouwerGeeftNotFound()
    {
        var response = await client.GetAsync("brouwers/-1");
        Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
        mock.Verify(repo => repo.FindByIdAsync(-1));
    }

    [TestMethod]
    public async Task GetMetBestaandeBrouwerGeeftOK()
    {
        mock.Setup(repo => repo.FindByIdAsync(1)).Returns(Task.FromResult<Brouwer?>(brouwer1));
        var response = await client.GetAsync("brouwers/1");
        Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        mock.Verify(repo => repo.FindByIdAsync(1));
        var body = await response.Content.ReadAsStringAsync();
        var document = JsonDocument.Parse(body);
        Assert.AreEqual(1, document.RootElement.GetProperty("id").GetInt32());
        Assert.AreEqual("1", document.RootElement.GetProperty("naam").GetString());
    }

    [TestMethod]
    public async Task PostMetCorrecteBrouwerGeeftCreated()
    {
        var response = await client.PostAsJsonAsync("brouwers", brouwer1);
        Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
        mock.Verify(repo => repo.InsertAsync(
        It.Is<Brouwer>(brouwer => brouwer.Id == 1)));
        mock.Verify(repo => repo.InsertAsync(
        It.Is<Brouwer>(brouwer => brouwer.Naam == "1")));
    }

    [TestMethod]
    public async Task PostMetVerkeerdeBrouwerGeeftBadRequest()
    {
        var response = await client.PostAsJsonAsync("brouwers",
        new Brouwer() { Id = 1, Naam = "1", Postcode = -1, Gemeente = "1" });
        Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        mock.Verify(repo => repo.InsertAsync(It.IsAny<Brouwer>()), Times.Never);
    }
}