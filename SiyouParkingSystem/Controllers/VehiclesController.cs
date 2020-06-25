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
    public class VehiclesController : ApiController
    {
        SYSDATAEntities SYS = new SYSDATAEntities();
        DateTime today = DateTime.UtcNow.Date;
        [Route("api/vehicles/Post")]
        [HttpPost]
        public IHttpActionResult Post(VehicleClass veh)
        {
            SYS.Vehicles.Add(new Vehicle()
            {
                PlateNumber = veh.PlateNumber,
                Model = veh.Model,
                Created_at = today,
                Updated_at = today,
                UserId = veh.UserId,
            });

            SYS.SaveChanges();
            return Ok();


        }
        [Route("api/vehicles")]
        public IEnumerable<VehicleClass> GetAll()
        {

            using (SYSDATAEntities SYS = new SYSDATAEntities())
            {
                List<VehicleClass> vehicleList = new List<VehicleClass>();

                foreach (var vehicle in SYS.Vehicles)
                {
                    
                    VehicleClass vehicleclass = new VehicleClass();
                    vehicleclass.Id = vehicle.Id;
                    vehicleclass.PlateNumber = vehicle.PlateNumber;
                    vehicleclass.Model = vehicle.Model;
                    vehicleclass.Created_at = vehicle.Created_at;
                    vehicleclass.Updated_at = vehicle.Updated_at;
                    vehicleclass.UserId = vehicle.UserId;
                    vehicleList.Add(vehicleclass);
                }
                IEnumerable<VehicleClass> veh = vehicleList;
                return veh;
            }
        }
        [Route("api/vehicles/getbyuser/{userid}")]
        [HttpGet]
        public IEnumerable<VehicleClass> getbyuser(int userid)
        {

            using (SYSDATAEntities SYS = new SYSDATAEntities())
            {
                List<VehicleClass> vehicleList = new List<VehicleClass>();

                foreach (var vehicle in SYS.Vehicles)
                {

                    VehicleClass vehicleclass = new VehicleClass();
                    vehicleclass.Id = vehicle.Id;
                    vehicleclass.PlateNumber = vehicle.PlateNumber;
                    vehicleclass.Model = vehicle.Model;
                    vehicleclass.Created_at = vehicle.Created_at;
                    vehicleclass.Updated_at = vehicle.Updated_at;
                    vehicleclass.UserId = vehicle.UserId;
                    if (vehicle.UserId == userid)
                    {
                        vehicleList.Add(vehicleclass);
                    }
                }
                IEnumerable<VehicleClass> veh = vehicleList;
                return veh;
            }
        }
        [Route("api/vehicles/{id}")]
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            List<VehicleClass> list = new List<VehicleClass>();
            var veh = SYS.Vehicles.FirstOrDefault(e => e.Id == id);
            if (veh == null)
            {
                return NotFound();
            }
            return Ok(veh);
        }
        [Route("api/vehicles/{id}")]
        [HttpPut]
        public HttpResponseMessage Put(int id, VehicleClass veh)
        {
            try
            {
                List<VehicleClass> list = new List<VehicleClass>();
                var entity = SYS.Vehicles.FirstOrDefault(e => e.Id == id);
                if (entity == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound,
                        "vehicle with Id " + id.ToString() + " not found to update");
                }
                else
                {
                    entity.PlateNumber = veh.PlateNumber;
                    entity.Model = veh.Model;
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
        [Route("api/vehicles/Delete/{id}")]
        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                using (SYSDATAEntities SYS = new SYSDATAEntities())
                {
                    var entity = SYS.Vehicles.FirstOrDefault(e => e.Id == id);

                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "vehicle with Id = " + id.ToString() + " does not exist");
                    }
                    else
                    {
                        SYS.Vehicles.Remove(entity);
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
