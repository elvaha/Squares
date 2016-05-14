using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquaresDataLibrary
{
    [Table("Set")]
    class ArtistSet
    {
        public String SetId { get; set; }
        public String Title { get; set; }
        public String Description { get; set; }
        public DateTime Date { get; set; }
        public double Rating { get; set; }
        public int viewCount { get; set; }
        public AspNetUser User { get; set; }
        public List<Piece> Pieces { get; set; }
    }
}
