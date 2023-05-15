using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using APILayer.Auth;
using BLL.DTOs;
using BLL.Services;

namespace APILayer.Controllers
{
    [Logged]
    public class ProfitController : ApiController
    {
        [FinanceAccess]
        [HttpGet]
        [Route("api/profits")]
        public IHttpActionResult Get()
        {
            try
            {
                var profit = ProfitServices.GetAllProfits();
                return ResponseMessage(profit == null
                    ? Request.CreateResponse(HttpStatusCode.NotFound)
                    : Request.CreateResponse(HttpStatusCode.OK, profit));
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.BadRequest, e.Message));
            }
        }


        [HttpGet]
        [Route("api/profits/{id}")]
        public IHttpActionResult Get(int id)
        {
            try
            {
                var profit = ProfitServices.GetprofitById(id);
                return ResponseMessage(profit == null
                    ? Request.CreateResponse(HttpStatusCode.NotFound)
                    : Request.CreateResponse(HttpStatusCode.OK, profit));
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.BadRequest, e.Message));
            }
        }


        [HttpPost]
        [Route("api/profits")]
        public IHttpActionResult Post([FromBody] ProfitDto profit)
        {
            try
            {
                var isAdded = ProfitServices.Addprofit(profit);
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
        [Route("api/profits")]
        public IHttpActionResult Patch([FromBody] ProfitDto profit)
        {
            try
            {
                var isUpdated = ProfitServices.Updateprofit(profit);
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
        [Route("api/profits/{id}")]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                var isDeleted = ProfitServices.Deleteprofit(id);
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