using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SiyouParkingSystem.Models
{
    public class UserClass
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }
        public string Role { get; set; }
    }
}