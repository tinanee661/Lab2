using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LaboratoriAnalizav.Models;
using Microsoft.AspNetCore.Mvc;


namespace LaboratoriAnalizav.Controllers
{
    public class DoctorController : Controller
    {
        public IActionResult Index()
        {
            var doctor = GetDoctors();
            ViewData["Doctor"] = doctor;
            return View();
        }


        private List<Doctor> GetDoctors()
        {
            var doctor = new List<Doctor>();

            doctor.Add(new Models.Doctor
            {
                Id = 1,
                FirstName = "Agim Bytyqi",
                Email = "a.bytyqi@out.com",
                Telephone = 09612327,
                Description = "Analiza t'alergjis",

            });
            doctor.Add(new Models.Doctor
            {
                Id = 2,
                FirstName = "Bardh Krasniqi",
                Email = "bardh.krasniqi@hotmail.com",
                Telephone = 94037974,
                Description = " Analiza t'gjendrrave",

            });
            doctor.Add(new Models.Doctor
            {
                Id = 3,
                FirstName = "Arta Neziraj",
                Email = "arta.neziraj@hotmail.com",
                Telephone = 09612327,
                Description = "Analiza t'gjendrrave",

            });

            doctor.Add(new Models.Doctor
            {
                Id = 4,
                FirstName = "Njazi Luma",
                Email = "njaziluma@gmail.com",
                Telephone = 94037974,
                Description = "Analiza t'gjakut",

            });
            return doctor;
        }

    }
}