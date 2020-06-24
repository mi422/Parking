using ParkingDataAccess;
using SiyouParkingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;


namespace SiyouParkingSystem.Controllers
{
    public class ContractsController : ApiController
    {      
        SYSDATAEntities SYS = new SYSDATAEntities();
        DateTime today = DateTime.Now.Date;
        [Route("api/contracts/Post")]
        [HttpPost]
        public IHttpActionResult Post(ContractClass Contra)
        {
            SYS.Contracts.Add(new Contract()
            {
                RenterId = Contra.RenterId,
                ParkingId = Contra.ParkingId,
                Rent = Contra.Rent,
                End_rent = Contra.End_rent,
                Created_at = today,
                Updated_at = today,
            });

            SYS.SaveChanges();
            return Ok();


        }
        [Route("api/Contracts")]
        public IEnumerable<ContractClass> GetAll()
        {
            using (SYSDATAEntities SYS = new SYSDATAEntities())
            {
                                
               
                List<ContractClass> contractList = new List<ContractClass>();

                foreach (var contract in SYS.Contracts)
                {
                    ContractClass contractClass = new ContractClass();
                    contractClass.Id = contract.Id;
                    contractClass.RenterId = contract.RenterId;
                    contractClass.ParkingId = contract.ParkingId;
                    contractClass.Rent = contract.Rent;
                    contractClass.End_rent = contract.End_rent;
                    contractClass.Created_at = contract.Created_at;
                    contractClass.Updated_at = contract.Updated_at;
                    contractList.Add(contractClass);
                }
               var Control = SYS.Contracts.Include("SYS.Renters");
                IEnumerable<ContractClass> contracts = contractList;
                return contracts;
            }
        }
        [Route("api/contracts/{id}")]
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            List<ContractClass> list = new List<ContractClass>();
            var contract = SYS.Contracts.FirstOrDefault(e => e.Id == id);
            if (contract == null)
            {
                return NotFound();
            }
            return Ok(contract);
        }
        [Route("api/contracts/{id}")]
        [HttpPut]
        public HttpResponseMessage Put(int id, ContractClass Contract)
        {
            try
            {
                List<ContractClass> list = new List<ContractClass>();
                var entity = SYS.Contracts.FirstOrDefault(e => e.Id == id);
                if (entity == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound,
                        "contract with Id " + id.ToString() + " not found to update");
                }
                else
                {
                    entity.End_rent = Contract.End_rent;
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
        [Route("api/contracts/DeleteContract/{id}")]
        [HttpDelete]
        public HttpResponseMessage DeleteContract(int id)
        {
            try
            {
                using (SYSDATAEntities SYS = new SYSDATAEntities())
                {
                    var entity = SYS.Contracts.FirstOrDefault(e => e.Id == id);

                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "contract with Id = " + id.ToString() + " does not exist");
                    }
                    else
                    {
                        SYS.Contracts.Remove(entity);
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
