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
            return Request.CreateResponse(HttpStatusCode.OK, SYS.Users.Where( e => e.Username == username));
        }

    }
}
