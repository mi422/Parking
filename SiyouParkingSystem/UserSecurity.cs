using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ParkingDataAccess;

namespace SiyouParkingSystem
{
    public class UserSecurity
    {
        public static bool Login(string username , string password)
        {
            using (SYSDATAEntities sys = new SYSDATAEntities())
            {
                return sys.Users.Any(user => user.Username.Equals(username, StringComparison.OrdinalIgnoreCase)
                  && user.Password == password);
            }


        }
    }
}