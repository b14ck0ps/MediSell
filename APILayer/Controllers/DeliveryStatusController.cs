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
    public class DeliveryStatusController : ApiController
    {
        [HttpGet]
        [Route("api/deliveryStatuses")]
        public IHttpActionResult Get()
        {
            try
            {
                var deliveryStatuses = DeliveryStatusServices.GetAllDeliveryStatuses();
                return ResponseMessage(deliveryStatuses == null
                    ? Request.CreateResponse(HttpStatusCode.NotFound)
                    : Request.CreateResponse(HttpStatusCode.OK, deliveryStatuses));
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.BadRequest, e.Message));
            }
        }

        [HttpGet]
        [Route("api/deliveryStatus/{id}")]
        public IHttpActionResult Get(int id)
        {
            try
            {
                var deliveryStatus = DeliveryStatusServices.GetdeliveryStatusById(id);
                return ResponseMessage(deliveryStatus == null
                    ? Request.CreateResponse(HttpStatusCode.NotFound)
                    : Request.CreateResponse(HttpStatusCode.OK, deliveryStatus));
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.BadRequest, e.Message));
            }
        }

        [HttpPost]
        [Route("api/deliveryStatus")]
        public IHttpActionResult Post([FromBody] DeliveryStatusDto deliverystatus)
        {
            try
            {
                var isAdded = DeliveryStatusServices.AdddeliveryStatus(deliverystatus);
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
        [Route("api/deliveryStatus")]
        public IHttpActionResult Patch([FromBody] DeliveryStatusDto deliverystatus)
        {
            try
            {
                var isUpdated = DeliveryStatusServices.UpdatedeliveryStatus(deliverystatus);
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
        [Route("api/deliveryStatus/{id}")]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                var isDeleted = DeliveryStatusServices.DeletedeliveryStatus(id);
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

