using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Squares.Models
{
    public class Gallery
    {

        public Gallery()
        {
        }

        public List<Set> getGalleryItems(int start, int limit, string sort)
        {
            using (var db = new SquaresDataContext())
            {

                IOrderedQueryable<Set> query = null;

                switch (sort)
                {
                    case "rating":
                        
                        query = db.Sets.Include("Author").OrderBy(x => x.Rating);

                        break;

                    default:

                        query = db.Sets.Include("Author").OrderBy(x => x.Title);

                        break;
                }

                return query.Skip(start)
                     .Take(limit)
                     .ToList<Set>();
            }
        }

        public List<Set> getGalleryDefault()
        {
            return getGalleryItems(0, 6, "rating");
        }

    }
}