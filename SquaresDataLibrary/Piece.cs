using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquaresDataLibrary
{
    [Table("Piece")]
    class SetPiece
    {
        public String PieceId { get; set; }
        public Set Set { get; set; }
        public String Url { get; set; }
    }
}
