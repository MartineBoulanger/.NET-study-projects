using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Tuincentrum.Filters;
using Tuincentrum.Models;

namespace Tuincentrum.Controllers
{
    //[StatistiekActionFilter] // action filter specifiek voor deze controller
    public class PlantController : Controller
    {
        private readonly MvctuinCentrumContext _context;
        private readonly IWebHostEnvironment webHostEnvironment;
        public PlantController(MvctuinCentrumContext context,
        IWebHostEnvironment environment)
        {
            _context = context;
            webHostEnvironment = environment;
        }

        // GET: Plant
        //[StatistiekActionFilter] // action filter specifiek voor deze action method
        //[StatistiekActionFilter(Order = 10)] // action filter voorzien met Order property
        public async Task<IActionResult> Index()
        {
            var mvctuinCentrumContext = _context.Planten.Include(p => p.LevnrNavigation).Include(p => p.SoortNrNavigation);
            return View(await mvctuinCentrumContext.ToListAsync());
        }

        // GET: Plant/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var plant = await _context.Planten
                .Include(p => p.LevnrNavigation)
                .Include(p => p.SoortNrNavigation)
                .FirstOrDefaultAsync(m => m.PlantNr == id);
            if (plant == null)
            {
                return NotFound();
            }

            return View(plant);
        }

        // GET: Plant/Create
        public IActionResult Create()
        {
            ViewData["Levnr"] = new SelectList(_context.Leveranciers, "LevNr", "Naam");
            ViewData["SoortNr"] = new SelectList(_context.Soorten, "SoortNr", "Naam");
            return View();
        }

        // POST: Plant/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PlantNr,Naam,SoortNr,Levnr,Kleur,VerkoopPrijs")] Plant plant)
        {
            if (ModelState.IsValid)
            {
                _context.Add(plant);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Levnr"] = new SelectList(_context.Leveranciers, "LevNr", "Naam", plant.Levnr);
            ViewData["SoortNr"] = new SelectList(_context.Soorten, "SoortNr", "Naam", plant.SoortNr);
            return View(plant);
        }

        // GET: Plant/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var plant = await _context.Planten.FindAsync(id);
            if (plant == null)
            {
                return NotFound();
            }
            ViewData["Levnr"] = new SelectList(_context.Leveranciers, "LevNr", "Naam", plant.Levnr);
            ViewData["SoortNr"] = new SelectList(_context.Soorten, "SoortNr", "Naam", plant.SoortNr);
            return View(plant);
        }

        // POST: Plant/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PlantNr,Naam,SoortNr,Levnr,Kleur,VerkoopPrijs")] Plant plant)
        {
            if (id != plant.PlantNr)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(plant);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlantExists(plant.PlantNr))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["Levnr"] = new SelectList(_context.Leveranciers, "LevNr", "Naam", plant.Levnr);
            ViewData["SoortNr"] = new SelectList(_context.Soorten, "SoortNr", "Naam", plant.SoortNr);
            return View(plant);
        }

        // GET: Plant/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var plant = await _context.Planten
                .Include(p => p.LevnrNavigation)
                .Include(p => p.SoortNrNavigation)
                .FirstOrDefaultAsync(m => m.PlantNr == id);
            if (plant == null)
            {
                return NotFound();
            }

            return View(plant);
        }

        // POST: Plant/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var plant = await _context.Planten.FindAsync(id);
            if (plant != null)
            {
                _context.Planten.Remove(plant);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlantExists(int id)
        {
            return _context.Planten.Any(e => e.PlantNr == id);
        }

        [HttpGet]
        public IActionResult Uploaden(int id)
        {
            var fotoUploadViewModel = new FotoUploadViewModel();
            fotoUploadViewModel.PlantNr = id;
            return View(fotoUploadViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> FotoUpload(FotoUploadViewModel vm)
        {
            if (vm.Foto != null && Path.GetExtension(vm.Foto.FileName) == ".jpg")
            {
                var fileName = vm.PlantNr.ToString() + ".jpg";
                var uploadfolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
                var filePath = Path.Combine(uploadfolder, fileName);
                using var fs = new FileStream(filePath, FileMode.Create);
                await vm.Foto.CopyToAsync(fs);
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult ZoekForm()
        {
            return View(new ZoekPlantViewModel());
        }

        public async Task<IActionResult> VanafPrijs(ZoekPlantViewModel form)
        {
            if (this.ModelState.IsValid)
            {
                var planten = await _context.Planten.OrderBy(s => s.Naam).Where(s => s.VerkoopPrijs >= form.Vanaf).ToListAsync();
                form.Planten = planten;
                if (planten.Count == 0)
                    ViewBag.ErrorMessage = $"Er zijn geen planten met een prijs vanaf {form.Vanaf}";
                else
                    ViewBag.ErrorMessage = String.Empty;
            }
            return View("ZoekForm", form);
        }

        public IActionResult FindPlantenBySoortNaam(string soortnaam)
        {
            List<Plant> plantenLijst = new List<Plant>();
            plantenLijst = (from plant in _context.Planten.Include(plant => plant.SoortNrNavigation).Include(plant => plant.LevnrNavigation)
                            where plant.SoortNrNavigation.Naam.StartsWith(soortnaam)
                            select plant).ToList();
            ViewBag.Title = "Planten van de soort '" + soortnaam + "'";
            return View("Plantenlijst", plantenLijst);
        }

        public IActionResult FindPlantenByLeverancier(int levnr)
        {
            List<Plant> plantenlijst = new List<Plant>();
            plantenlijst = (from plant in _context.Planten.Include(p => p.LevnrNavigation).Include(p => p.SoortNrNavigation) where plant.LevnrNavigation.LevNr == levnr select plant).ToList();
            var leverancier = _context.Leveranciers.Find(levnr);
            ViewBag.Title = "Planten van leverancier '" + leverancier.Naam + "'";
            return View("Plantenlijst", plantenlijst);
        }

        public IActionResult FindPlantenByKleur(string kleur)
        {
            List<Plant> plantenlijst = new List<Plant>();
            plantenlijst = (from plant in _context.Planten.Include(p => p.LevnrNavigation).Include(p => p.SoortNrNavigation) where plant.Kleur.ToLower() == kleur.ToLower() select plant).ToList();
            return View(nameof(Index), plantenlijst);
        }

        public IActionResult FindPlantenBetweenPrijzen(decimal minPrijs, decimal maxPrijs)
        {
            List<Plant> plantenlijst = new List<Plant>();
            plantenlijst = (from plant in _context.Planten.Include(p => p.SoortNrNavigation).Include(p => p.LevnrNavigation) where plant.VerkoopPrijs >= minPrijs && plant.VerkoopPrijs <= maxPrijs select plant).ToList();
            ViewBag.Title = $"Planten met prijs tussen €{minPrijs} en €{maxPrijs}";
            return View("Plantenlijst", plantenlijst);
        }

        [Route("plantinfo/{id:int}")]
        public IActionResult FindPlantById(int id)
        {
            var plant = _context.Planten.Where(p => p.PlantNr == id).Include(p => p.LevnrNavigation).Include(p => p.SoortNrNavigation).FirstOrDefault();
            if (plant == null)
                return NotFound();
            return ToonPlantInfo(plant);
        }

        [Route("plantinfo/{naam}")]
        public IActionResult FindPlantByName(string naam)
        {
            var plant = _context.Planten.Where(p => p.Naam.ToLower() == naam.ToLower()).Include(p => p.LevnrNavigation).Include(p => p.SoortNrNavigation).FirstOrDefault();
            if (plant == null)
                return NotFound();
            return ToonPlantInfo(plant);
        }

        [NonAction]
        private IActionResult ToonPlantInfo(Plant plant)
        {
            if (plant != null) return View(nameof(Details), plant);
            else
            {
                var planten = _context.Planten.Include(p => p.LevnrNavigation).Include(p => p.SoortNrNavigation);
                return View(nameof(Index), planten.ToList());
            }
        }

        [Route("plantenprijzen/{btw:values(inclusief|exclusief)}", Name = "btwinex")]
        public IActionResult PrijsLijst (string btw)
        {
            ViewBag.Btw = btw;
            return View(_context.Planten.ToList());
        }
    }
}
