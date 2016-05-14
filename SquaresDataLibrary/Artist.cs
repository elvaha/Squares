using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquaresDataLibrary
{
    [Table("Author")]
    class Artist
    {

        public AspNetRole Role { get; set; }
        public AspNetUser User { get; set; }
        public String Alias { get; set; }
        public String Description { get; set; }
        public DateTime Date { get; set; }
        public List<Set> Sets { get; set; }

    }
}
