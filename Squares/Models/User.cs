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
        public String PhoneNumber { get; set; }
        public String UserName { get; set; }
        public String Address { get; set; }

        public User()
        {

        }


        public User GetUser(String UserId)
        {
            SquaresDataContext db = new SquaresDataContext();

            String alias = "";
            String description = "";

            AspNetUser user = db.AspNetUsers.Where(x => x.Id == UserId).FirstOrDefault();
            Artist author = db.Artists.Where(x => x.UserId == UserId).FirstOrDefault();

            if (author != null)
            {
                alias = author.Alias;
                description = author.Description;
            }

            User CurrentUser = new User()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                UserName = user.UserName,
                Address = user.Address,
            };

            return CurrentUser;
        } 
    }
}