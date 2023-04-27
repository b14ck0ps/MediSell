using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL.DTOs;
using BLL.Services;

namespace APILayer.Controllers
{
    public class OrderController : ApiController
    {
        [HttpGet]
        [Route("api/orders")]
        public IHttpActionResult GetAllOrders()
        {
            try
            {
                var orders = OrderServices.GetAllOrders();
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, orders));
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message));
            }
        }

        [HttpGet]
        [Route("api/order/{id}")]
        public IHttpActionResult GetOrderById(int id)
        {
            try
            {
                var order = OrderServices.GetOrderById(id);
                return ResponseMessage(order == null
                    ? Request.CreateResponse(HttpStatusCode.NotFound)
                    : Request.CreateResponse(HttpStatusCode.OK, order));
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message));
            }
        }

        [HttpGet]
        [Route("api/order/customer/{id}")]
        public IHttpActionResult GetAllOrdersByCustomerId(int id)
        {
            try
            {
                var orders = OrderServices.GetAllOrdersByCustomerId(id);
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, orders));
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message));
            }
        }

        [HttpPost]
        [Route("api/order")]
        public IHttpActionResult AddOrder([FromBody] OrderDto order)
        {
            try
            {
                var result = OrderServices.AddOrder(order);
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, result));
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message));
            }
        }

        [HttpPut]
        [Route("api/order")]
        public IHttpActionResult UpdateOrder([FromBody] OrderDto order)
        {
            try
            {
                var result = OrderServices.UpdateOrder(order);
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, result));
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message));
            }
        }

        [HttpDelete]
        [Route("api/order/{id}")]
        public IHttpActionResult DeleteOrder(int id)
        {
            try
            {
                var result = OrderServices.DeleteOrder(id);
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, result));
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message));
            }
        }
    }
}