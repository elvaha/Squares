using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquaresDataLibrary
{
    class DataHandler
    {

        private DataHandler() {}

        public static List<vTopRated> getGalleryItems(int start, int limit, string sort)
        {
            using (var db = new DataClassesSquaresDataContext())
            {

                IOrderedQueryable<vTopRated> query = null;

                switch(sort)
                {
                    case "rating":

                        query = db.vTopRateds.OrderBy(x => x.Rating);

                    break;

                    default:

                        query = db.vTopRateds.OrderBy(x => x.Title);

                    break;
                }

               return query.Skip(start)
                    .Take(limit)
                    .ToList<vTopRated>();
            }
        }

        public static List<vTopRated> getGalleryDefault()
        {
            return getGalleryItems(0, 6, "rating");
        }

    }
}
