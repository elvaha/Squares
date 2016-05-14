using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SquaresDataLibrary
{
    public class Gallery
    {


        public Gallery()
        {

        }

        // ordered by Rating as default, can be sorted afterwards
        public List<Set> Sets()
        {
            DataClassesSquaresDataContext db = new DataClassesSquaresDataContext();
            List<Set> sets = db.Sets.OrderBy(x => x.Rating).ToList();

            return sets;
        }

    }
}