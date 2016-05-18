using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Squares.Models
{
    public class Gallery
    {


        public Gallery()
        {

        }

        // ordered by Rating as default, can be sorted afterwards
        public List<ArtistSet> Sets()
        {
            SquaresDataContext db = new SquaresDataContext();
            List<ArtistSet> sets = db.Sets.OrderBy(x => x.Rating).ToList();

            return sets;
        }

    }
}