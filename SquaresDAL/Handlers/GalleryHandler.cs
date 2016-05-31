using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquaresDAL.Handlers
{
    public class GalleryHandler
    {

        private GalleryHandler() {}

        public static List<Set> searchSets(int skip, int take, int sort, string searchStr)
        {
            using (var db = new SquaresEntities())
            {

                DbQuery<Set> entryList = db.Sets
                    .Include("Artist")
                    .Include("SetPieces");

                IOrderedQueryable<Set> orderedList = null;

                switch (sort)
                {
                    case 1:

                        orderedList = entryList
                            .OrderByDescending(x => x.Rating)
                            .ThenByDescending(x => x.ViewCount);

                        break;
                    case 2:

                        orderedList = entryList
                            .OrderByDescending(x => x.ViewCount)
                            .ThenByDescending(x => x.Rating);

                        break;
                    case 3:

                        orderedList = entryList
                            .OrderByDescending(x => x.Date)
                            .ThenByDescending(x => x.ViewCount)
                            .ThenByDescending(x => x.Rating);

                        break;

                    default:
                        break;
                }

                return orderedList
                    .Where(x => x.Title.Contains(searchStr) || x.Description.Contains(searchStr))
                    .Skip(skip)
                    .Take(take)
                    .ToList<Set>();

            }
        }

        public static List<Artist> searchAuthors(int skip, int take, int sort, string searchStr)
        {

            using (var db = new SquaresEntities())
            {

                DbQuery<Artist> entryList = db.Artists
                    .Include("Set");

                IOrderedQueryable<Artist> orderedList = null;

                switch (sort)
                {
                    case 1:

                        orderedList = db.Artists
                            .OrderByDescending(x => x.Sets.Average(s => s.Rating))
                            .ThenByDescending(x => x.Sets.Sum(s => s.ViewCount));

                        break;
                    case 2:

                        orderedList = db.Artists
                            .OrderByDescending(x => x.Sets.Sum(s => s.ViewCount))
                            .ThenByDescending(x => x.Sets.Average(s => s.Rating));


                        break;
                    case 3:

                        orderedList = entryList
                            .OrderByDescending(x => x.Date)
                            .ThenByDescending(x => x.Sets.Average(s => s.Rating))
                            .ThenByDescending(x => x.Sets.Sum(s => s.ViewCount));

                        break;

                    default:
                        break;
                }

                return orderedList
                    .Where(x => x.Alias.Contains(searchStr) || x.Description.Contains(searchStr))
                    .Skip(skip)
                    .Take(take)
                    .ToList<Artist>();

            }

        }

        public static List<Set> getSets()
        {
            using (var db = new SquaresEntities())
            {
                return db.Sets
                    .Include("Artist")
                    .ToList<Set>();
            }
        }

        public static void setSetStatus(int id, bool status)
        {
            using (var db = new SquaresEntities())
            {
                Set s = db.Sets.Find(id);
                s.isDisabled = !s.isDisabled;
                db.SaveChanges();
            }
        }

    }
}
