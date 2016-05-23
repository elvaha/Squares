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

                List<Set> sets = new List<Set>();

                switch (sort)
                {
                    case "RATING":

                        sets = db.Sets.OrderBy(x => x.Rating).ToList();

                        break;

                    case "NEW":

                        sets = db.Sets.OrderBy(x => x.Date).ToList();

                        break;

                    default:

                        sets = db.Sets.OrderBy(x => x.Title).ToList();

                        break;
                }

                return sets;
            }
        }


        public List<Set> getIndexGallery()
        {
            SquaresDataContext db = new SquaresDataContext();
            List<Set> indexSets = new List<Set>();

            if (db.Sets.Count() > 6)
            {
                indexSets = db.Sets.Skip(0).Take(6).OrderBy(x => x.Rating).ToList();
            }
            else
            {
                indexSets = db.Sets.ToList();
            }


            return indexSets;
        }

    }
}