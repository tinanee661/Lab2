﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace LaboratoriAnalizav.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        public string FirstName { get; set; }

        public string Email { get; set; }

        public int Telephone { get; set; }

        public string Description { get; set; }
    }
}
