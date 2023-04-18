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
    public class AccountCashInController : ApiController
    {
        [HttpGet]
        [Route("api/AccountCashIns")]
        public IHttpActionResult Get()
        {
            try
            {
                var CashIn = AccountCashInServices.GetAllAccountCashIns();
                return ResponseMessage(CashIn == null
                    ? Request.CreateResponse(HttpStatusCode.NotFound)
                    : Request.CreateResponse(HttpStatusCode.OK, CashIn));
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.BadRequest, e.Message));
            }
        }

        [HttpGet]
        [Route("api/AccountCashIns/{id}")]
        public IHttpActionResult Get(int id)
        {
            try
            {
                var CashIn = AccountCashInServices.GetAccountCashInById(id);
                return ResponseMessage(CashIn == null
                    ? Request.CreateResponse(HttpStatusCode.NotFound)
                    : Request.CreateResponse(HttpStatusCode.OK, CashIn));
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.BadRequest, e.Message));
            }
        }


        [HttpPost]
        [Route("api/AccountCashIns")]
        public IHttpActionResult Post([FromBody] AccountCashInDto AccountCashIn)
        {
            try
            {
                var isAdded = AccountCashInServices.AddAccountCashIn(AccountCashIn);
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
        [Route("api/AccountCashIns")]
        public IHttpActionResult Patch([FromBody] AccountCashInDto AccountCashIn)
        {
            try
            {
                var isUpdated = AccountCashInServices.UpdateAccountCashIn(AccountCashIn);
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
        [Route("api/AccountCashIns/{id}")]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                var isDeleted = AccountCashInServices.DeleteAccountCashIn(id);
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
