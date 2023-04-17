using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APILayer.Controllers
{
    public class ProfitController : ApiController
    {
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
    }
}
