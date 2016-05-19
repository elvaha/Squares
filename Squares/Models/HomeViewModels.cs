using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Squares.Models
{
    public class Profile
    {
        public string Alias { get; set; }
        public string Description { get; set; }
        public List<string> ImageUrls { get; set; }
    }
}