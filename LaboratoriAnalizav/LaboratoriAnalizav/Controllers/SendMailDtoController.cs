using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReflectionIT.Mvc.Paging;
using LaboratoriAnalizav.Data;
using LaboratoriAnalizav.Models;

namespace LaboratoriAnalizav.Controllers
{

    public class SendMailDtoController : Controller
    {

        private readonly ApplicationDbContext _context;

        public SendMailDtoController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(int page = 1)
        {
            var query = _context.SendMails.AsNoTracking().OrderBy(s => s.id);
            var model = await PagingList.CreateAsync(query, 3, page);
            return View(model);
        }



        public IActionResult Create()
        {
            return View();
        }


        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,LastName,Subject,Message,User")] SendMailDto sendMail)
        {
            System.Diagnostics.Debug.WriteLine("testet");
            if (ModelState.IsValid)
            {
                _context.Add(sendMail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Create));
            }

            return NotFound("Mail was not saved!!");

        }

    }
}