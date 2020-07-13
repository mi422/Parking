using ParkingDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SiyouParkingSystem.Models;

namespace SiyouParkingSystem.Controllers
{
    public class RentersController : ApiController
    {
        SYSDATAEntities SYS = new SYSDATAEntities();
        DateTime today = DateTime.UtcNow.Date;
        [Route("api/renters/Post")]
        [HttpPost]
        public IHttpActionResult Post(RenterClass rent)
        {
            SYS.Renters.Add(new Renter()
            {
                Name = rent.Name,
                Phone = rent.Phone,
                QR_code = rent.QR_code,
                Adress = rent.Adress,
                UserId = rent.UserId,
                Created_at = today,
                Updated_at = today
            });

            SYS.SaveChanges();
            return Ok();


        }
        [Route("api/Renters")]
        public IEnumerable<RenterClass> GetAll()
        {

            using (SYSDATAEntities SYS = new SYSDATAEntities())
            {
                List<RenterClass> renterList = new List<RenterClass>();

                foreach (var renter in SYS.Renters)
                {
                    RenterClass renterclass = new RenterClass();
                    renterclass.Id = renter.Id;
                    renterclass.Name = renter.Name;
                    renterclass.Phone = renter.Phone;
                    renterclass.QR_code = renter.QR_code;
                    renterclass.Adress = renter.Adress;
                    renterclass.UserId = renter.UserId;
                    renterclass.Created_at = renter.Created_at;
                    renterclass.Updated_at = renter.Updated_at;
                    renterList.Add(renterclass);
                }
                IEnumerable<RenterClass> rent = renterList;
                return rent;
            }
        }
        [Route("api/renters/{id}")]
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            List<RenterClass> list = new List<RenterClass>();
            var rent = SYS.Renters.FirstOrDefault(e => e.Id == id);
            if (rent == null)
            {
                return NotFound();
            }
            return Ok(rent);
        }
        [Route("api/renters/getbyuser/{userid}")]
        [HttpGet]
        public IEnumerable<RenterClass> getbyuser(int userid)
        {

            using (SYSDATAEntities SYS = new SYSDATAEntities())
            {
                List<RenterClass> renterList = new List<RenterClass>();

                foreach (var renter in SYS.Renters)
                {
                    RenterClass renterclass = new RenterClass();
                    renterclass.Id = renter.Id;
                    renterclass.Name = renter.Name;
                    renterclass.Phone = renter.Phone;
                    renterclass.QR_code = renter.QR_code;
                    renterclass.Adress = renter.Adress;
                    renterclass.UserId = renter.UserId;
                    renterclass.Created_at = renter.Created_at;
                    renterclass.Updated_at = renter.Updated_at;
                    if (renter.UserId == userid)
                    {
                        renterList.Add(renterclass);
                    }
                }
                IEnumerable<RenterClass> rent = renterList;
                return rent;
            }
        }
        [Route("api/renters/{id}")]
        [HttpPut]
        public HttpResponseMessage Put(int id, RenterClass rent)
        {
            try
            {
                List<RenterClass> list = new List<RenterClass>();
                var entity = SYS.Renters.FirstOrDefault(e => e.Id == id);
                if (entity == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound,
                        "Renter with Id " + id.ToString() + " not found to update");
                }
                else
                {
                    entity.Name = rent.Name;
                    entity.Phone = rent.Phone;
                    entity.QR_code = rent.QR_code;
                    entity.Adress = rent.Adress;
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
        [Route("api/renters/Delete/{id}")]
        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                using (SYSDATAEntities SYS = new SYSDATAEntities())
                {
                    var entity = SYS.Renters.FirstOrDefault(e => e.Id == id);

                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Renter with Id = " + id.ToString() + " does not exist");
                    }
                    else
                    {
                        SYS.Renters.Remove(entity);
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
        [Route("api/renters/QRCode/{QR}")]
        public IHttpActionResult QRCode(int QR)
        {
            var result = !SYS.Renters.ToList().Exists(x => x.QR_code.Equals(QR));
            return Ok(result);
        }
    }
}
