using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquaresDAL.Handlers
{
    public class UserHandler
    {

        private UserHandler() {}

        public static List<vTopArtist> getTopArtists()
        {
            using (var db = new SquaresEntities()) {

                return db.vTopArtists
                    .OrderByDescending(x => x.AverageRating)
                    .OrderByDescending(x => x.TotalViews)
                    .Take(10)
                    .ToList<vTopArtist>();

            }
        }

        public static List<AspNetUser> getUsers()
        {
            using (var db = new SquaresEntities())
            {
                return db.AspNetUsers.ToList<AspNetUser>();
            }
        }

        public static void setUserStatus(int id, bool status)
        {
            using (var db = new SquaresEntities())
            {
                AspNetUser user = db.AspNetUsers.Find(id);
                user.HasAccess = !user.HasAccess;
                db.SaveChanges();
            }
        }

    }
}
