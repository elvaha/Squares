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
        public List<Set> Sets()
        {
            SquaresDataContext db = new SquaresDataContext();
            List<Set> sets = db.Sets.OrderBy(x => x.Rating).ToList();

            return sets;
        }

    }
}