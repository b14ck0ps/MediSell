using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL.DTOs;
using BLL.Services;

namespace APILayer.Controllers.CustomerApi
{
    public class CustomerController : ApiController
    {
        [HttpGet]
        [Route("api/customer")]
        public IHttpActionResult Get()
        {
            try
            {
                var customers = CustomerServices.GetAllCustomers();
                return ResponseMessage(customers == null
                    ? Request.CreateResponse(HttpStatusCode.NotFound)
                    : Request.CreateResponse(HttpStatusCode.OK, customers));
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.BadRequest, e.Message));
            }
        }

        [HttpGet]
        [Route("api/customer/{id}")]
        public IHttpActionResult Get(int id)
        {
            try
            {
                var customer = CustomerServices.GetCustomerById(id);
                return ResponseMessage(customer == null
                    ? Request.CreateResponse(HttpStatusCode.NotFound)
                    : Request.CreateResponse(HttpStatusCode.OK, customer));
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.BadRequest, e.Message));
            }
        }

        [HttpPost]
        [Route("api/customer")]
        public IHttpActionResult Post([FromBody] UserDto customer)
        {
            try
            {
                var isAdded = CustomerServices.AddCustomer(customer);
                return ResponseMessage(isAdded
                    ? Request.CreateResponse(HttpStatusCode.Created)
                    : Request.CreateResponse(HttpStatusCode.BadRequest));
            }
            catch (Exception e)
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.BadRequest, e.Message));
            }
        }

        [HttpPatch]
        [Route("api/customer")]
        public IHttpActionResult Patch([FromBody] UserDto customer)
        {
            try
            {
                var isUpdated = CustomerServices.UpdateCustomer(customer);
                return ResponseMessage(isUpdated
                    ? Request.CreateResponse(HttpStatusCode.OK)
                    : Request.CreateResponse(HttpStatusCode.BadRequest));
            }
            catch (Exception e)
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.BadRequest, e.Message));
            }
        }

        [HttpDelete]
        [Route("api/customer/{id}")]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                var isDeleted = CustomerServices.DeleteCustomer(id);
                return ResponseMessage(isDeleted
                    ? Request.CreateResponse(HttpStatusCode.OK)
                    : Request.CreateResponse(HttpStatusCode.BadRequest));
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.BadRequest, e.Message));
            }
        }
    }
}