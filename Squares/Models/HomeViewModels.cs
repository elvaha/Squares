﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Squares.Models
{
    public class Profile
    {
        public string Alias { get; set; }
        public string Description { get; set; }
        public List<Set> Sets { get; set; }
    }

    public class indexModel
    {
        public List<Set> sets { get; set; }
    }

    public class searchModel
    {
        public string searchParam { get; set; }
        public string searchPlace { get; set; }
    }
}