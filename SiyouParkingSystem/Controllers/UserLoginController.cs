using ParkingDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;
using System.Web.Http.Cors;

namespace SiyouParkingSystem.Controllers
{
    [BasicAthentication]
    public class UserLoginController : ApiController
    {
        SYSDATAEntities SYS = new SYSDATAEntities();
        [Route("api/UserLogin/{username}")]
        public HttpResponseMessage GetUserLogin()
        {
            string username = Thread.CurrentPrincipal.Identity.Name;
            SYSDATAEntities sys = new SYSDATAEntities();
            if (sys.Users.Any(user => user.Username.Equals(username, StringComparison.OrdinalIgnoreCase)))
            {

                return Request.CreateResponse(HttpStatusCode.OK, SYS.Users.Where(e => e.Username == username));
            }
            else

            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound,
                    " User not found ");
            }           
        }

    }
}
