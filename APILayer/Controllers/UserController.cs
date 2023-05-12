using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using APILayer.Auth;
using BLL.DTOs;
using BLL.Services;

namespace APILayer.Controllers
{
    public class UserController : ApiController
    {
        [HttpGet]
        [Route("api/users")]
        [Logged]
        public IHttpActionResult Get()
        {
            try
            {
                var customers = UserServices.GetAllUsers();
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
        [Route("api/user/{id}")]
        [Logged]
        public IHttpActionResult Get(int id)
        {
            try
            {
                var customer = UserServices.GetuserById(id);
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
        [Route("api/user")]
        public IHttpActionResult Post([FromBody] UserDto customer)
        {
            try
            {
                var isAdded = UserServices.Adduser(customer);
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
        [Logged]
        [Route("api/user")]
        public IHttpActionResult Patch([FromBody] UserDto customer)
        {
            try
            {
                var isUpdated = UserServices.Updateuser(customer);
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
        [Logged]
        [AdminAccess]
        [Route("api/user/{id}")]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                var isDeleted = UserServices.Deleteuser(id);
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