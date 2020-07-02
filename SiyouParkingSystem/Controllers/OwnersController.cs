using ParkingDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SiyouParkingSystem.Models;
using System.Web.Http.Results;

namespace SiyouParkingSystem.Controllers
{ 
    public class OwnersController : ApiController
    {
        SYSDATAEntities SYS = new SYSDATAEntities();
        DateTime today = DateTime.UtcNow.Date;
        [Route("api/owners/Post")]
        [HttpPost]
        public IHttpActionResult Post(OwnerClass own)
        {
            int lastUserId = SYS.Users.Max(User => User.Id);
            SYS.Owners.Add(new Owner()
            {
                FirstName = own.FirstName,
                LastName = own.LastName,
                Phone = own.Phone,
                QR_code = own.QR_code,
                Adress = own.Adress,
                Birth_date = own.Birth_date,
                Created_at = today,
                Updated_at = today,
                UserId = lastUserId,
            });

            SYS.SaveChanges();
            return Ok();
        }
        [Route("api/owners")]
        public IEnumerable<OwnerClass> GetAll()
        {

            using (SYSDATAEntities SYS = new SYSDATAEntities())
            {
                List<OwnerClass> ownerList = new List<OwnerClass>();

                foreach (var owner in SYS.Owners)
                {
                    OwnerClass ownerclass = new OwnerClass();
                    ownerclass.Id = owner.Id;
                    ownerclass.FirstName = owner.FirstName;
                    ownerclass.LastName = owner.LastName;
                    ownerclass.Phone = owner.Phone;
                    ownerclass.QR_code = owner.QR_code;
                    ownerclass.Adress = owner.Adress;
                    ownerclass.Birth_date = owner.Birth_date;
                    ownerclass.Created_at = owner.Created_at;
                    ownerclass.Updated_at = owner.Updated_at;
                    ownerclass.UserId = owner.UserId;
                    ownerList.Add(ownerclass);
                }
                IEnumerable<OwnerClass> own = ownerList;
                return own;
            }
        }
        [Route("api/owners/{id}")]
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            List<OwnerClass> list = new List<OwnerClass>();
            var own = SYS.Owners.FirstOrDefault(e => e.Id == id);
            if (own == null)
            {
                return NotFound();
            }
            return Ok(own);
        }
        //GETOwnerByUserId
        [Route("api/owners/GETUSERIDD/{Userid}")]
        [HttpGet]
        public IHttpActionResult GETUSERIDD(int Userid)
        {
            List<OwnerClass> list = new List<OwnerClass>();
            var ownn = SYS.Owners.FirstOrDefault(e => e.UserId == Userid);
            if (ownn == null)
            {
                return NotFound();
            }
            return Ok(ownn);
        }
        [Route("api/owners/{id}")]
        [HttpPut]
        public HttpResponseMessage Put(int id, OwnerClass Owner)
        {
            try
            {
                List<OwnerClass> list = new List<OwnerClass>();
                var entity = SYS.Owners.FirstOrDefault(e => e.Id == id);
                if (entity == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound,
                        "owner with Id " + id.ToString() + " not found to update");
                }
                else
                {
                    entity.FirstName = Owner.FirstName;
                    entity.LastName = Owner.LastName;
                    entity.Phone = Owner.Phone;
                    entity.QR_code = Owner.QR_code;
                    entity.Adress = Owner.Adress;
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
        [Route("api/owners/Delete/{id}")]
        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                using (SYSDATAEntities SYS = new SYSDATAEntities())
                {
                    var entity = SYS.Owners.FirstOrDefault(e => e.Id == id);

                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Owner with Id = " + id.ToString() + " does not exist");
                    }
                    else
                    {
                        SYS.Owners.Remove(entity);
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
