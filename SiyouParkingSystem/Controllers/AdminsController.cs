using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ParkingDataAccess;
using SiyouParkingSystem.Models;



namespace SiyouParkingSystem.Controllers
{
    public class AdminsController : ApiController
    {       //master oumayma
        SYSDATAEntities SYS = new SYSDATAEntities();
        DateTime today = DateTime.UtcNow.Date;
        [Route("api/admins/PostAdmin")]
        [HttpPost]
        public IHttpActionResult PostAdmin(AdminClass Admi)
        {
            int lastUserId = SYS.Users.Max(User => User.Id);
            SYS.Admins.Add(new Admin()
            {
                FirstName = Admi.FirstName,
                LastName = Admi.LastName,
                Phone = Admi.Phone,
                Address = Admi.Address,
                Birth_date = Admi.Birth_date,
                Created_at = today,
                Updated_at = today,
                UserId = lastUserId
            });

            SYS.SaveChanges();
            return Ok();


        }
        [Route("api/Admins")]
        public IEnumerable<AdminClass> GetAll()
        {

            using (SYSDATAEntities SYS = new SYSDATAEntities())
            {
                List<AdminClass> AdminList = new List<AdminClass>();

                foreach (var admin in SYS.Admins)
                {
                    AdminClass adminClass = new AdminClass();
                    adminClass.Id = admin.Id;
                    adminClass.FirstName = admin.FirstName;
                    adminClass.LastName = admin.LastName;
                    adminClass.Phone = admin.Phone;
                    adminClass.Address = admin.Address;
                    adminClass.Birth_date = admin.Birth_date;
                    adminClass.Created_at = admin.Created_at;
                    adminClass.Updated_at = admin.Updated_at;
                    adminClass.UserId = admin.UserId;
                    AdminList.Add(adminClass);
                }
                IEnumerable<AdminClass> Adm = AdminList;
                return Adm;
            }
        }
        [Route("api/admins/{id}")]
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            List<AdminClass> list = new List<AdminClass>();
            var adm = SYS.Admins.FirstOrDefault(e => e.Id == id);
            if (adm == null)
            {
                return NotFound();
            }
            return Ok(adm);
        }
        [Route("api/admins/{id}")]
        [HttpPut]
        public HttpResponseMessage Put(int id, AdminClass Admin)
        {
            try
            {
                List<AdminClass> list = new List<AdminClass>();
                var entity = SYS.Admins.FirstOrDefault(e => e.Id == id);
                if (entity == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound,
                        "Admin with Id " + id.ToString() + " not found to update");
                }
                else
                {
                    entity.FirstName = Admin.FirstName;
                    entity.LastName = Admin.LastName;
                    entity.Phone = Admin.Phone;
                    entity.Address = Admin.Address;
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
        [Route("api/admins/DeleteAdmin/{id}")]
        [HttpDelete]
        public HttpResponseMessage DeleteAdmin(int id)
        {
            try
            {
                using (SYSDATAEntities SYS = new SYSDATAEntities())
                {
                    var entity = SYS.Admins.FirstOrDefault(e => e.Id == id);

                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Admin with Id = " + id.ToString() + " does not exist");
                    }
                    else
                    {
                        SYS.Admins.Remove(entity);
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



