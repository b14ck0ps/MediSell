using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

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
                var CashOut = AccountCashOutServices.GetAllAccountCashOuts();
                return ResponseMessage(CashOut == null
                    ? Request.CreateResponse(HttpStatusCode.NotFound)
                    : Request.CreateResponse(HttpStatusCode.OK, CashOut));
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
                var CashOut = AccountCashOutServices.GetAccountCashOutById(id);
                return ResponseMessage(CashOut == null
                    ? Request.CreateResponse(HttpStatusCode.NotFound)
                    : Request.CreateResponse(HttpStatusCode.OK, CashOut));
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.BadRequest, e.Message));
            }
        }


        [HttpPost]
        [Route("api/AccountCashOuts")]
        public IHttpActionResult Post([FromBody] AccountCashOutDto AccountCashOut)
        {
            try
            {
                var isAdded = AccountCashOutServices.AddAccountCashOut(AccountCashOut);
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
        public IHttpActionResult Patch([FromBody] AccountCashOutDto AccountCashOut)
        {
            try
            {
                var isUpdated = AccountCashOutServices.UpdateAccountCashOut(AccountCashOut);
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
