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


        public List<Set> WholeGallery()
        {
            SquaresDataContext db = new SquaresDataContext();
            List<Set> Sets = new List<Set>();

            Sets = db.Sets.OrderBy(x => x.Rating).ToList();

            return Sets;
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

        public List<Set> getIndexGallery()
        {
            SquaresDataContext db = new SquaresDataContext();
            List<Set> indexSets = new List<Set>();

            if (db.Sets.Count() > 6)
            {
                indexSets = db.Sets.Skip(0).Take(6).OrderBy(x=> x.Rating).ToList();
            }
            else
            {
                indexSets = db.Sets.ToList();
            }
           

            return indexSets;
        }

    }
}