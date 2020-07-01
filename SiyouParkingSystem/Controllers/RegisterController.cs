using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SiyouParkingSystem.Models;
using ParkingDataAccess;

namespace SiyouParkingSystem.Controllers
{
    public class RegisterController : ApiController
    {
        SYSDATAEntities SYS = new SYSDATAEntities();
        DateTime today = DateTime.UtcNow.Date;

        [Route("api/Register/RegisterUser")]
        [HttpPost()]
        public IHttpActionResult RegisterUser(UserClass us)
        {
            var result = SYS.Users.Add(new User()
            {
                Email = us.Email,
                Username = us.Username,
                Password = us.Password,
                Role = us.Role,
                Created_at = today,
                Updated_at = today

            });
            SYS.SaveChanges();
            return Ok(result);
        }
        [Route("api/register")]
        public IEnumerable<UserClass> GetAll()
        {

            using (SYSDATAEntities SYS = new SYSDATAEntities())
            {
                List<UserClass> userList = new List<UserClass>();

                foreach (var User in SYS.Users)
                {
                    UserClass userclass = new UserClass();
                    userclass.Id = User.Id;
                    userclass.Email = User.Email;
                    userclass.Username = User.Username;
                    userclass.Created_at = User.Created_at;
                    userclass.Updated_at = User.Updated_at;
                    userclass.Password = User.Password;
                    userclass.Role = User.Role;
                    userList.Add(userclass);
                }
                IEnumerable<UserClass> Us = userList;
                return Us;
            }
        }
        [Route("api/register/GetRole")]
        [HttpGet]
        public IEnumerable<UserClass> GetRole()
        {

            using (SYSDATAEntities SYS = new SYSDATAEntities())
            {
                List<UserClass> ownersList = new List<UserClass>();
                foreach (var User in SYS.Users)
                {
                    UserClass userclass = new UserClass();
                    userclass.Id = User.Id;
                    userclass.Email = User.Email;
                    userclass.Username = User.Username;
                    userclass.Created_at = User.Created_at;
                    userclass.Updated_at = User.Updated_at;
                    userclass.Password = User.Password;
                    userclass.Role = User.Role;
                    
                    if (User.Role == "Owner")
                    {
                        ownersList.Add(userclass);
                        
                    }
                }
                IEnumerable<UserClass> Us = ownersList;
                return Us;
            }
        }
        [Route("api/Register/Get/{id}")]
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            List<UserClass> list = new List<UserClass>();

            var us = SYS.Users.FirstOrDefault(e => e.Id == id);
            int lastUserId = SYS.Users.Max(User => User.Id);
            if (us == null)
            {
                return NotFound();
            }
            return Ok(us);
        }
        [Route("api/Register/Getcurrent/{username}")]
        [HttpGet]
        public IHttpActionResult Getcurrent(string username)
        {
            List<UserClass> list = new List<UserClass>();

            var us = SYS.Users.FirstOrDefault(e => e.Username == username);
            if (us == null)
            {
                return NotFound();
            }
            return Ok(us);
        }
        [Route("api/register/{id}")]
        [HttpPut]
        public HttpResponseMessage Put(int id, UserClass use)
        {
            try
            {
                List<UserClass> list = new List<UserClass>();
                var entity = SYS.Users.FirstOrDefault(e => e.Id == id);
                if (entity == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound,
                        "User with Id " + id.ToString() + " not found to update");
                }
                else
                {

                    entity.Email = use.Email;
                    entity.Username = use.Username;
                    entity.Password = use.Password;
                    entity.Role = use.Role;
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
        [Route("api/register/DeleteUser/{id}")]
        [HttpDelete]
        public HttpResponseMessage DeleteUser(int id)
        {
            try
            {
                using (SYSDATAEntities SYS = new SYSDATAEntities())
                {
                    var entit = SYS.Users.FirstOrDefault(e => e.Id == id);

                    if (entit == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "User with Id = " + id.ToString() + " does not exist");
                    }
                    else
                    {
                        SYS.Users.Remove(entit);
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
        [Route("api/register/CheckUsername/{usern}")]
        [HttpGet]
        public IHttpActionResult CheckUsername(string usern)
        {
            var result = !SYS.Users.ToList().Exists(x => x.Username.Equals(usern, StringComparison.CurrentCultureIgnoreCase));
            return Ok(result);
        }
        [Route("api/register/mail/{email}")]
        [HttpGet]
        public IHttpActionResult mail(string email)
        {
            var result = !SYS.Users.ToList().Exists(x => x.Username.Equals(email, StringComparison.CurrentCultureIgnoreCase));
            return Ok(result);
        }
    }
 }



