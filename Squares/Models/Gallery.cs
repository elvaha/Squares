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

            Sets = db.Sets.Include("Artist").Include("SetPiece").OrderBy(x => x.Rating).ToList();

            return Sets;
        }


        public List<Set> getGalleryItems(string sort)
        {
            SquaresDataContext db = new SquaresDataContext();

            List<Set> sets = new List<Set>();

            switch (sort)
            {
                case "RATING":

                    sets = db.Sets.Include("Artist").OrderByDescending(x => x.Rating).ToList();

                    break;

                case "NEW":

                    sets = db.Sets.Include("Artist").OrderByDescending(x => x.Date).ToList();

                    break;

                case "VIEWS":

                    sets = db.Sets.OrderByDescending(x => x.ViewCount).ToList();

                    break;

                default:

                    sets = WholeGallery();

                    break;
            }

            return sets;
        }


        public List<Set> getIndexGallery()
        {
            SquaresDataContext db = new SquaresDataContext();
            List<Set> indexSets = new List<Set>();

            if (db.Sets.Count() >= 6)
            {
                indexSets = db.Sets.Include("Artist").Include("SetPiece").Skip(0).Take(6).OrderBy(x => x.Rating).ToList();
            }
            else
            {
                indexSets = db.Sets.ToList();
            }


            return indexSets;
        }

        public List<Set> SearchGallery(string searchParam, string searchPlace)
        {
            SquaresDataContext db = new SquaresDataContext();
            List<Set> searchSet = new List<Set>();
            
            switch (searchPlace)
            {

                case "ARTIST":
                    searchSet = db.Sets.Where(x => x.Artist.Alias.Contains(searchParam)).ToList();

                    break;
                case "SET":
                    searchSet = db.Sets.Where(x => x.Title.Contains(searchParam) || x.Description.Contains(searchParam)).ToList();
                    break;

                default:
                    searchSet = WholeGallery();
                    break;
            }

            return searchSet;
        }

    }
}