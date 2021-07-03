using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LaboratoriAnalizav.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReflectionIT.Mvc.Paging;

namespace LaboratoriAnalizav.Areas.AdminPanel.Controllers
{

    [Authorize(Roles = "Admin")]
    [Area("AdminPanel")]

    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var query = _context.Users.AsNoTracking().OrderBy(s => s.UserName);
            return View(query);
        }



        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var user = await _context.Users.FindAsync(id);
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }



    }
}