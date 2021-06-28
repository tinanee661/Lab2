using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReflectionIT.Mvc.Paging;
using Microsoft.AspNetCore.Authorization;
using LaboratoriAnalizav.Data;
using LaboratoriAnalizav.Models;

namespace LaboratoriPerAnaliza.Controllers
{
    public class TerminetsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TerminetsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Terminets
        public async Task<IActionResult> Index(int page = 1)
        {
            var query = _context.Terminets.AsNoTracking().OrderBy(s => s.Name);
            var model = await PagingList.CreateAsync(query, 3, page);
            return View(model);
        }

        [Authorize]
        // GET: Terminets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var terminet = await _context.Terminets
                .FirstOrDefaultAsync(m => m.Id == id);
            if (terminet == null)
            {
                return NotFound();
            }

            return View(terminet);
        }


        [Authorize]
        // GET: Terminets/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Terminets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Email,Contact,Startdate,Enddate")] Terminet terminet)
        {
            if (ModelState.IsValid)
            {
                _context.Add(terminet);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(terminet);
        }

        [Authorize]
        // GET: Terminets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var terminet = await _context.Terminets.FindAsync(id);
            if (terminet == null)
            {
                return NotFound();
            }
            return View(terminet);
        }

        // POST: Terminets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Email,Contact,Startdate,Enddate")] Terminet terminet)
        {
            if (id != terminet.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(terminet);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TerminetExists(terminet.Id))
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
            return View(terminet);
        }

        // GET: Terminets/Delete/5

        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var terminet = await _context.Terminets
                .FirstOrDefaultAsync(m => m.Id == id);
            if (terminet == null)
            {
                return NotFound();
            }

            return View(terminet);
        }

        // POST: Terminets/Delete/5

        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var terminet = await _context.Terminets.FindAsync(id);
            _context.Terminets.Remove(terminet);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TerminetExists(int id)
        {
            return _context.Terminets.Any(e => e.Id == id);
        }
    }
}
