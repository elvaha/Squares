using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace SquaresDataLibrary
{
    [Table("AspNetUsers")]
    public class User
    {
        public String Id { get; set; }
        public String Email { get; set; }
        public Boolean EmailConfirmed { get; set; }
        public String PasswordHash { get; set; }
        public String PhoneNumber { get; set; }
        public String UserName { get; set; }
        public Zipcode ZipCode { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Address { get; set; }
        public String Orginization { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime Birthday { get; set; }
    }
}
