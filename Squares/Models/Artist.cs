using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Squares.Models
{
    public class Artist
    {
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String PhoneNumber { get; set; }
        public String UserName { get; set; }
        public String Address { get; set; }
        public String Alias { get; set; }
        public String Description { get; set; }

        public Artist()
        {

        }


        public Artist GetArtist(String UserId)
        {
            SquaresDataContext db = new SquaresDataContext();

            AspNetUser user = db.AspNetUsers.Single(x => x.Id == UserId);
            Author author = db.Authors.Single(x => x.UserId == UserId);

            Artist artist = new Artist()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                UserName = user.UserName,
                Address = user.Address,
                Alias = author.Alias,
                Description = author.Description
            };

            return artist;
        } 
    }
}