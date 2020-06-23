using ParkingDataAccess;
using SiyouParkingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SiyouParkingSystem.Controllers
{
 
    public class ParkingSessionsController : ApiController
    {
        SYSDATAEntities SYS = new SYSDATAEntities();
        DateTime today = DateTime.UtcNow.Date;
        [Route("api/parkingSessions")]
        public IEnumerable<ParkingSessionsClass> GetAll()
        {

            using (SYSDATAEntities SYS = new SYSDATAEntities())
            {
                List<ParkingSessionsClass> List = new List<ParkingSessionsClass>();

                foreach (var sessions in SYS.Parking_sessions)
                {
                    ParkingSessionsClass sessionsclass = new ParkingSessionsClass();
                    sessionsclass.Id = sessions.Id;
                    sessionsclass.Entry_date = sessions.Entry_Date;
                    sessionsclass.Extry_date = sessions.Extry_Date;
                    sessionsclass.Created_at = sessions.Created_at;
                    sessionsclass.Updated_at = sessions.Updated_at;
                    sessionsclass.VehicleId = sessions.VehicleId;
                    List.Add(sessionsclass);
                }
                IEnumerable<ParkingSessionsClass> session = List;
                return session;
            }
        }
        [Route("api/parkingSessions/{id}")]
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            List<ParkingSessionsClass> list = new List<ParkingSessionsClass>();
            var session = SYS.Parking_sessions.FirstOrDefault(e => e.Id == id);
            if (session == null)
            {
                return NotFound();
            }
            return Ok(session);
        }
    }
}
