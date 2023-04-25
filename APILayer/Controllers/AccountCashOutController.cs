using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL.DTOs;
using BLL.Services;

namespace APILayer.Controllers
{
    public class AccountCashOutController : ApiController
    {
        [HttpGet]
        [Route("api/AccountCashOuts")]
        public IHttpActionResult Get()
        {
            try
            {
                var cashOuts = AccountCashOutServices.GetAllAccountCashOuts();
                return ResponseMessage(cashOuts == null
                    ? Request.CreateResponse(HttpStatusCode.NotFound)
                    : Request.CreateResponse(HttpStatusCode.OK, cashOuts));
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.BadRequest, e.Message));
            }
        }


        [HttpGet]
        [Route("api/AccountCashOuts/{id}")]
        public IHttpActionResult Get(int id)
        {
            try
            {
                var cashOut = AccountCashOutServices.GetAccountCashOutById(id);
                return ResponseMessage(cashOut == null
                    ? Request.CreateResponse(HttpStatusCode.NotFound)
                    : Request.CreateResponse(HttpStatusCode.OK, cashOut));
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.BadRequest, e.Message));
            }
        }


        [HttpPost]
        [Route("api/AccountCashOuts")]
        public IHttpActionResult Post([FromBody] AccountCashOutDto accountCashOutDto)
        {
            try
            {
                var isAdded = AccountCashOutServices.AddAccountCashOut(accountCashOutDto);
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
        [Route("api/AccountCashOuts")]
        public IHttpActionResult Patch([FromBody] AccountCashOutDto accountCashOutDto)
        {
            try
            {
                var isUpdated = AccountCashOutServices.UpdateAccountCashOut(accountCashOutDto);
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
        [Route("api/AccountCashOuts/{id}")]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                var isDeleted = AccountCashOutServices.DeleteAccountCashOut(id);
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