using BrouwerService.Controllers;
using BrouwerService.Models;
using BrouwerService.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace BrouwerServiceUnitTests
{
    [TestClass]
    public class BrouwerControllerTest
    {
        BrouwerController controller = null!;
        Mock<IBrouwerRepository> mock = null!;
        Brouwer brouwer7 = null!, brouwer9 = null!;

        [TestInitialize]
        public void Initialize()
        {
            mock = new Mock<IBrouwerRepository>();
            var repository = mock.Object;
            controller = new BrouwerController(repository);
            brouwer7 = new Brouwer { Id = 7, Naam = "7", Postcode = 7000, Gemeente = "7" };
            brouwer9 = new Brouwer { Id = 9, Naam = "9", Postcode = 9000, Gemeente = "9" };
        }

        [TestMethod]
        public async Task DeleteGeeftNotFoundBijOnbestaandeBrouwer()
        {
            Assert.IsInstanceOfType<NotFoundResult>(await controller.Delete(-1));
            mock.Verify(repo => repo.DeleteAsync(It.IsAny<Brouwer>()), Times.Never);
        }

        [TestMethod]
        public async Task DeleteVerwijdertBestaandeBrouwer()
        {
            mock.Setup(repo => repo.FindByIdAsync(7)).Returns(Task.FromResult<Brouwer?>(brouwer7));
            Assert.IsInstanceOfType<OkResult>(await controller.Delete(7));
            mock.Verify(repo => repo.DeleteAsync(brouwer7));
        }

        [TestMethod]
        public async Task FindByIdGeeftNotFoundBijOnbestaandeBrouwer()
        {
            Assert.IsInstanceOfType<NotFoundResult>(await controller.FindById(-1));
            mock.Verify(repo => repo.FindByIdAsync(-1));
        }

        [TestMethod]
        public async Task FindByIdGeeftBestaandeBrouwer()
        {
            mock.Setup(repo => repo.FindByIdAsync(7)).Returns(Task.FromResult<Brouwer?>(brouwer7));
            var response = (OkObjectResult)await controller.FindById(7);
            var brouwer = (Brouwer)response.Value!;
            Assert.AreEqual(7, brouwer.Id);
            mock.Verify(repo => repo.FindByIdAsync(7));
        }

        [TestMethod]
        public async Task FindAllGeeftAlleBrouwers()
        {
            var alleBrouwers = new List<Brouwer>() { brouwer7, brouwer9 };
            mock.Setup(repo => repo.FindAllAsync()).Returns(Task.FromResult(alleBrouwers));
            var response = (OkObjectResult)await controller.FindAll();
            var brouwers = (List<Brouwer>)response.Value!;
            Assert.HasCount(2, brouwers);
            Assert.AreEqual(7, brouwers[0].Id);
            Assert.AreEqual(9, brouwers[1].Id);
            mock.Verify(repo => repo.FindAllAsync());
        }

        [TestMethod]
        public async Task FindByBeginNaamGeeftJuisteBrouwers()
        {
            var brouwersMetBeginNaam7 = new List<Brouwer>() { brouwer7 };
            mock.Setup(repo => repo.FindByBeginNaamAsync("7")).Returns(Task.FromResult(brouwersMetBeginNaam7));
            var response = (OkObjectResult)await controller.FindByBeginNaam("7");
            var brouwers = (List<Brouwer>)response.Value!;
            Assert.HasCount(1, brouwers);
            Assert.AreEqual(7, brouwers[0].Id);
            mock.Verify(repo => repo.FindByBeginNaamAsync("7"));
        }

        [TestMethod]
        public async Task PostVoegtBrouwerToe()
        {
            var brouwer = new Brouwer() { Naam = "N", Postcode = 1000, Gemeente = "N" };
            var response = (CreatedAtActionResult)await controller.Post(brouwer);
            mock.Verify(repo => repo.InsertAsync(brouwer));
        }

        [TestMethod]
        public async Task PutGeeftNotFoundBijOnbestaandeBrouwer()
        {
            mock.Setup(repo => repo.UpdateAsync(brouwer7)).Throws(new DbUpdateConcurrencyException());
            Assert.IsInstanceOfType<NotFoundResult>(await controller.Put(7, brouwer7));
            mock.Verify(repo => repo.UpdateAsync(brouwer7));
        }

        [TestMethod]
        public async Task PutWijzigtBestaandeBrouwer()
        {
            Assert.IsInstanceOfType<OkResult>(await controller.Put(7, brouwer7));
            mock.Verify(repo => repo.UpdateAsync(brouwer7));
        }
    }
}
