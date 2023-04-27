using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APILayer.Controllers
{
    public class ProductController : ApiController
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
    }
}
