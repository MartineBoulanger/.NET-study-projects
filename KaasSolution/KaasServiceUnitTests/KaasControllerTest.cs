using KaasService.Controllers;
using KaasService.Models;
using KaasService.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
namespace KaasServiceUnitTests;

[TestClass]
public class KaasControllerTest
{
    KaasController controller = null!;
    Mock<IKaasRepository> mock = null!;
    Kaas kaas7 = null!, kaas9 = null!;

    [TestInitialize]
    public void Initialize()
    {
        mock = new Mock<IKaasRepository>();
        var repository = mock.Object;
        controller = new KaasController(repository);
        kaas7 = new Kaas { Id = 7, Naam = "7", Smaak = "7", Soort = "7" };
        kaas9 = new Kaas { Id = 9, Naam = "9", Smaak = "9", Soort = "9" };
    }

    [TestMethod]
    public async Task FindbyIdGeeftNotFoundBijOnbestaandeKaas()
    {
        Assert.IsInstanceOfType<NotFoundResult>(await controller.FindById(7));
        mock.Verify(repo => repo.FindByIdAsync(7));
    }

    [TestMethod]
    public async Task FindByIdGeeftBestaandeKaasTerug()
    {
        mock.Setup(repo => repo.FindByIdAsync(7)).Returns(Task.FromResult<Kaas?>(kaas7));
        var response = (OkObjectResult)await controller.FindById(7);
        var kaas = (Kaas)response.Value!;
        Assert.AreEqual(7, kaas.Id);
        mock.Verify(repo => repo.FindByIdAsync(7));
    }

    [TestMethod]
    public async Task FindAllGeeftAlleKazenTerug()
    {
        var alleKazen = new List<Kaas>() { kaas7, kaas9 };
        mock.Setup(repo => repo.FindAllAsync()).Returns(Task.FromResult(alleKazen));
        var response = (OkObjectResult)await controller.FindAll();
        var kazen = (List<Kaas>)response.Value!;
        Assert.HasCount(2, kazen);
        Assert.AreEqual(7, kazen[0].Id);
        Assert.AreEqual(9, kazen[1].Id);
        mock.Verify(repo => repo.FindAllAsync());
    }

    [TestMethod]
    public async Task FindBySmaakGeeftJuisteKazenTerug()
    {
        var kazenMetSmaak7 = new List<Kaas>() { kaas7 };
        mock.Setup(repo =>
        repo.FindBySmaakAsync("7")).Returns(Task.FromResult(kazenMetSmaak7));
        var response = (OkObjectResult)await controller.FindBySmaak("7");
        var kazen = (List<Kaas>)response.Value!;
        Assert.HasCount(1, kazen);
        Assert.AreEqual(7, kazen[0].Id);
        mock.Verify(repo => repo.FindBySmaakAsync("7"));
    }

    [TestMethod]
    public async Task PutGeeftNotFoundBijOnbestaandeKaas()
    {
        mock.Setup(repo => repo.UpdateAsync(kaas7))
        .Throws(new DbUpdateConcurrencyException());
        Assert.IsInstanceOfType<NotFoundResult>(await controller.Put(7, kaas7));
        mock.Verify(repo => repo.UpdateAsync(kaas7));
    }

    [TestMethod]
    public async Task PutWijzigtKaas()
    {
        Assert.IsInstanceOfType<OkResult>(await controller.Put(7, kaas7));
        mock.Verify(repo => repo.UpdateAsync(kaas7));
    }
}