using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LaboratoriAnalizav.Models;
using LaboratoriAnalizav.Data;
using Microsoft.AspNetCore.Authorization;

namespace LaboratoriAnalizav.Controllers
{
    public class CalendarController : Controller
    {
        private readonly ApplicationDbContext _context;

        
        public CalendarController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> GetEventData() {
            List<Terminet> ObjEmp =await _context.Terminets.ToListAsync();
            //return list as Json
            return Json(ObjEmp);
        }
    }
}