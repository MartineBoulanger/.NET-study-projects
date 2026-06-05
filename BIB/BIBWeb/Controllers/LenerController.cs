using BIBData.Models;
using BIBServices;
using BIBWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BIBWeb.Controllers
{
    public class LenerController:Controller
    {
        private readonly LenerService service;
        private readonly UitleningService uitleningService;
        private readonly ReserveringService reserveringService;
        public LenerController(LenerService lenerService, UitleningService uitleningService, ReserveringService reserveringService)
        {
            service = lenerService;
            this.uitleningService = uitleningService;
            this.reserveringService = reserveringService;
        }

        public IActionResult Index()
        {
            return View(service.GetAllLeners());
        }

        public IActionResult Detail(int id)
        {
            LenerDetailViewModel? lenerDetailViewModel = null;
            Lener? lener = service.GetLener(id);
            if (lener == null)
                ViewBag.ErrorMessage = $"Geen info gevonden voor lener met id {id}";
            else
                lenerDetailViewModel = new LenerDetailViewModel
                {
                    Lener = lener,
                    OpenstaandeUitleningen = uitleningService.GetOpenstaandeUitleningenVanLener(id),
                    Reserveringen = reserveringService.GetReserveringenVanLener(id)
                };
            return View(lenerDetailViewModel);
        }
    }
}
