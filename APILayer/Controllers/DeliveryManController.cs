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
    public class DeliveryManController : ApiController
    {
        [HttpGet]
        [Route("api/deliveryMen")]
        public IHttpActionResult Get()
        {
            try
            {
                var deliverymen = DeliveryManServices.GetAllDeliveryMen();
                return ResponseMessage(deliverymen == null
                    ? Request.CreateResponse(HttpStatusCode.NotFound)
                    : Request.CreateResponse(HttpStatusCode.OK, deliverymen));
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.BadRequest, e.Message));
            }
        }

        [HttpGet]
        [Route("api/deliveryMen/{id}")]
        public IHttpActionResult Get(int id)
        {
            try
            {
                var deliverymen = DeliveryManServices.GetdeliveryManById(id);
                return ResponseMessage(deliverymen == null
                    ? Request.CreateResponse(HttpStatusCode.NotFound)
                    : Request.CreateResponse(HttpStatusCode.OK, deliverymen));
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.BadRequest, e.Message));
            }
        }
        [HttpPost]
        [Route("api/deliveryMan")]
        public IHttpActionResult Post([FromBody] DeliveryManDto deliverymen)
        {
            try
            {
                var isAdded = DeliveryManServices.Adddeliveryman(deliverymen);
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
        [Route("api/deliveryMan")]
        public IHttpActionResult Patch([FromBody] DeliveryManDto deliverymen)
        {
            try
            {
                var isUpdated = DeliveryManServices.UpdatedeliveryMan(deliverymen);
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
        [Route("api/deliveryMan/{id}")]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                var isDeleted = DeliveryManServices.DeletedeliveryMan(id);
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
