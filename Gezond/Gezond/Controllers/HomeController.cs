using Azure.Storage.Blobs;
using Gezond.Models;
using Gezond.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Gezond.Controllers
{
    public class HomeController : Controller
    {
        private readonly GezondContext context;
        private readonly BlobContainerClient blobContainerClient;

        public HomeController(GezondContext context, BlobServiceClient blobServiceClient)
        {
            this.context = context;
            blobContainerClient = blobServiceClient.GetBlobContainerClient("groentenafbeeldingen");
            blobContainerClient.CreateIfNotExists();
        }

        public async Task<IActionResult> Index() => View(await context.Groenten.AsNoTracking().ToListAsync());

        public async Task<IActionResult> Detail(int id)
        {
            var groente = await context.Groenten.FindAsync(id);
            return groente == null ? RedirectToAction(nameof(Index)) : View(groente);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> AfbeeldingToevoegen(int id, IFormFile bestand)
        {
            var blobClient = blobContainerClient.GetBlobClient(id.ToString());
            await blobClient.UploadAsync(bestand.OpenReadStream(), true);
            return RedirectToAction(nameof(Detail), new { Id = id });
        }

        [ResponseCache(NoStore = true, Duration = 0)]
        public async Task<IActionResult> Afbeelding(int id)
        {
            var blobClient = blobContainerClient.GetBlobClient(id.ToString());
            if (await blobClient.ExistsAsync())
            {
                var memoryStream = new MemoryStream();
                await blobClient.DownloadToAsync(memoryStream);
                memoryStream.Position = 0;
                return new FileStreamResult(memoryStream, "application/octet-stream");
            }
            return File("leeg.png", "application/octet-stream");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
