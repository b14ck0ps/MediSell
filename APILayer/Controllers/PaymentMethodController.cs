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
    public class PaymentMethodController : ApiController
    {
        [HttpGet]
        [Route("api/paymentmethods")]
        public IHttpActionResult Get()
        {
            try
            {
                var payments = PaymentMethodServices.GetAllPaymentMethods();
                return ResponseMessage(payments == null
                    ? Request.CreateResponse(HttpStatusCode.NotFound)
                    : Request.CreateResponse(HttpStatusCode.OK, payments));
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.BadRequest, e.Message));
            }
        }

        [HttpGet]
        [Route("api/paymentmethod/{id}")]
        public IHttpActionResult Get(int id)
        {
            try
            {
                var payment = PaymentMethodServices.GetpaymentmethodById(id);
                return ResponseMessage(payment == null
                    ? Request.CreateResponse(HttpStatusCode.NotFound)
                    : Request.CreateResponse(HttpStatusCode.OK, payment));
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.BadRequest, e.Message));
            }
        }

        [HttpPost]
        [Route("api/paymentmethod")]
        public IHttpActionResult Post([FromBody] PaymentMethodDto payment)
        {
            try
            {
                var isAdded = PaymentMethodServices.Addpaymentmethod(payment);
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
        [Route("api/paymentmethod")]
        public IHttpActionResult Patch([FromBody] PaymentMethodDto payment)
        {
            try
            {
                var isUpdated = PaymentMethodServices.Updatepaymentmethod(payment);
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
        [Route("api/paymentmethod/{id}")]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                var isDeleted = PaymentMethodServices.Deletepaymentmethod(id);
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

