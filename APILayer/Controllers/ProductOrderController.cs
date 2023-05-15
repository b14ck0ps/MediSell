using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL.DTOs;
using BLL.Services;

namespace APILayer.Controllers
{
    public class ProductOrderController : ApiController
    {
        [HttpGet]
        [Route("api/productorder")]
        public IHttpActionResult GetAllProductsOrder()
        {
            try
            {
                var productsOrder = ProductOrderService.GetAllProductsOrder();
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, productsOrder));
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message));
            }
        }

        [HttpGet]
        [Route("api/productorder/{id}")]
        public IHttpActionResult GetProductOrderById(int id)
        {
            try
            {
                var productOrder = ProductOrderService.GetProductOrderById(id);
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, productOrder));
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message));
            }
        }

        [HttpPost]
        [Route("api/productorder")]
        public IHttpActionResult AddProductOrder([FromBody] List<ProductsOrderDto> productOrder)
        {
            try
            {
                var result = ProductOrderService.AddProductOrders(productOrder);
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, result));
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message));
            }
        }

        [HttpPut]
        [Route("api/productorder")]
        public IHttpActionResult UpdateProductOrder([FromBody] ProductsOrderDto productOrder)
        {
            try
            {
                var result = ProductOrderService.UpdateProductOrder(productOrder);
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, result));
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message));
            }
        }

        [HttpDelete]
        [Route("api/productorder/{id}")]
        public IHttpActionResult DeleteProductOrder(int id)
        {
            try
            {
                var result = ProductOrderService.DeleteProductOrder(id);
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, result));
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message));
            }
        }

        [HttpGet]
        [Route("api/productorder/order/{orderId}")]
        public IHttpActionResult GetProductsOrderForOrder(int orderId)
        {
            try
            {
                var productsOrder = ProductOrderService.GetProductsOrderForOrder(orderId);
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, productsOrder));
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message));
            }
        }
    }
}