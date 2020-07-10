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
    public class ParkingsController : ApiController
    {
        SYSDATAEntities SYS = new SYSDATAEntities();
        DateTime today = DateTime.UtcNow.Date;
        [Route("api/parkings/Post")]
        [HttpPost]
        public IHttpActionResult Post(ParkingClass par)
        {
            SYS.Parkings.Add(new Parking()
            {
                Position = par.Position,
                Created_at = today,
                Updated_at = today,
                UserId = par.UserId,
            });

            SYS.SaveChanges();
            return Ok();


        }
        [Route("api/parkings")]
        public IEnumerable<ParkingClass> GetAll()
        {

            using (SYSDATAEntities SYS = new SYSDATAEntities())
            {
                List<ParkingClass> parkingList = new List<ParkingClass>();

                foreach (var parking in SYS.Parkings)
                {
                    ParkingClass parkingClass = new ParkingClass();
                    parkingClass.Id = parking.Id;
                    parkingClass.Position = parking.Position;
                    parkingClass.Created_at = parking.Created_at;
                    parkingClass.Updated_at = parking.Updated_at;
                    parkingClass.UserId = parking.UserId;
                    parkingList.Add(parkingClass);
                }
                IEnumerable<ParkingClass> par = parkingList;
                return par;
            }
        }
        [Route("api/parkings/{id}")]
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            List<ParkingClass> list = new List<ParkingClass>();
            var par = SYS.Parkings.FirstOrDefault(e => e.Id == id);
            if (par == null)
            {
                return NotFound();
            }
            return Ok(par);
        }
        [Route("api/parkings/getbyuser/{userid}")]
        [HttpGet]
        public IEnumerable<ParkingClass> getbyuser(int userid)
        {

            using (SYSDATAEntities SYS = new SYSDATAEntities())
            {
                List<ParkingClass> parkingList = new List<ParkingClass>();

                foreach (var parking in SYS.Parkings)
                { 
                    ParkingClass parkingClass = new ParkingClass();
                    parkingClass.Id = parking.Id;
                    parkingClass.Position = parking.Position;
                    parkingClass.Created_at = parking.Created_at;
                    parkingClass.Updated_at = parking.Updated_at;
                    parkingClass.UserId = parking.UserId;
                    if (parking.UserId == userid)
                    {
                        parkingList.Add(parkingClass);
                    }
                }
                IEnumerable<ParkingClass> par = parkingList;
                return par;
            }
        }
        [Route("api/parkings/{id}")]
        [HttpPut]
        public HttpResponseMessage Put(int id, ParkingClass par)
        {
            try
            {
                List<ParkingClass> list = new List<ParkingClass>();
                var entity = SYS.Parkings.FirstOrDefault(e => e.Id == id);
                if (entity == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound,
                        "parking with Id " + id.ToString() + " not found to update");
                }
                else
                {
                    entity.Position = par.Position;
                    entity.Updated_at = today;
                    SYS.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK, entity);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
        [Route("api/parkings/Delete/{id}")]
        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                using (SYSDATAEntities SYS = new SYSDATAEntities())
                {
                    var entity = SYS.Parkings.FirstOrDefault(e => e.Id == id);

                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "parking with Id = " + id.ToString() + " does not exist");
                    }
                    else
                    {
                        SYS.Parkings.Remove(entity);
                        SYS.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK);
                    }
                }

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }     
    }
}
