﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFMovieRentalDomain
{
    public class User : BaseDomain
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }
    }
}
