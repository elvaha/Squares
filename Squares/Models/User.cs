using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Squares.Models
{
    public class User
    {
        public String FirstName { get; set; }
        public String LastName { get; set; }
        //public String PhoneNumber { get; set; }
        public String UserName { get; set; }
        //public String Address { get; set; }
        public bool IsArtist { get; set; }
        public String Alias { get; set; }
        public String Description { get; set; }

        public User()
        {

        }


        public User GetUser(String UserId)
        {
            SquaresDataContext db = new SquaresDataContext();

            String alias = "";
            String description = "";
            Artist artist = null;

            AspNetUser user = db.AspNetUsers.Where(x => x.Id == UserId).FirstOrDefault();


            User CurrentUser = new User()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                //PhoneNumber = user.PhoneNumber,
                UserName = user.UserName,
                //Address = user.Address,
                IsArtist = (bool)user.IsArtist,
            };

            if ((bool)user.IsArtist)
            {
                artist = db.Artists.Where(x => x.UserId == UserId).FirstOrDefault();

                if (artist != null)
                {
                    alias = artist.Alias;
                    description = artist.Description;
                }

                CurrentUser.Alias = alias;
                CurrentUser.Description = Description;
            }

            return CurrentUser;
        }
    }
}