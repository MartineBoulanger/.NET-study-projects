using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
//using Tuincentrum.Filters;
using Tuincentrum.Models;

namespace Tuincentrum.Controllers
{
    //[TypeFilter(typeof(CustomExceptionFilter))]
    public class SoortController:Controller
    {
        private readonly MvctuinCentrumContext _context;

        public SoortController(MvctuinCentrumContext context)
        {
            _context = context;
        }

        // GET: Soort
        public async Task<IActionResult> Index()
        {
            //int deler = 0;
            //int resultaat = 5 / deler; // om een arithmetic error te triggeren
            //throw new Exception(); // om een algemen error te triggeren
            return View(await _context.Soorten.ToListAsync());
        }

        // GET: Soort/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var soort = await _context.Soorten
                .FirstOrDefaultAsync(m => m.SoortNr == id);
            if (soort == null)
            {
                return NotFound();
            }

            return View(soort);
        }

        // GET: Soort/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Soort/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SoortNr,Naam,MagazijnNr")] Soort soort)
        {
            if (ModelState.IsValid)
            {
                _context.Add(soort);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(soort);
        }

        // GET: Soort/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var soort = await _context.Soorten.FindAsync(id);
            if (soort == null)
            {
                return NotFound();
            }
            return View(soort);
        }

        // POST: Soort/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SoortNr,Naam,MagazijnNr")] Soort soort)
        {
            if (id != soort.SoortNr)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(soort);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SoortExists(soort.SoortNr))
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
            return View(soort);
        }

        // GET: Soort/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var soort = await _context.Soorten
                .FirstOrDefaultAsync(m => m.SoortNr == id);
            if (soort == null)
            {
                return NotFound();
            }

            return View(soort);
        }

        // POST: Soort/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var soort = await _context.Soorten.FindAsync(id);
            if (soort != null)
            {
                _context.Soorten.Remove(soort);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SoortExists(int id)
        {
            return _context.Soorten.Any(e => e.SoortNr == id);
        }

        // GET: /Soort/Zoekform
        public IActionResult ZoekForm()
        {
            return View(new ZoekSoortViewModel());
        }

        public async Task<IActionResult> BeginNaam(ZoekSoortViewModel form)
        {
            if (this.ModelState.IsValid)
            {
                form.Soorten = await _context.Soorten.OrderBy(s => s.Naam).Where(s => s.Naam.StartsWith(form.BeginNaam)).ToListAsync();
                if (form.Soorten.Count == 0)
                    ViewBag.ErrorMessage = $"Er zijn geen soorten beginnend met {form.BeginNaam}";
                else
                    ViewBag.ErrorMessage = String.Empty;
            }
            return View("ZoekForm", form);
        }
    }
}
