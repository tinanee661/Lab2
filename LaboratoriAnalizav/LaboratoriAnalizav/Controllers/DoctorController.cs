﻿using System;
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
            return View();
        }
    }
}