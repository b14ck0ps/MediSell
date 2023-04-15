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
    public class CompanyController : ApiController
    {
        [HttpGet]
        [Route("api/companies")]
        public IHttpActionResult Get()
        {
            try
            {
                var companies = CompanyServices.GetAllCompany();
                return ResponseMessage(companies == null
                    ? Request.CreateResponse(HttpStatusCode.NotFound)
                    : Request.CreateResponse(HttpStatusCode.OK, companies));
            }
            catch(Exception e)
            {
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.BadRequest, e.Message));
            }
        }

        //addCompany
        [HttpPost]
        [Route("api/addcompany")]
        public IHttpActionResult Post([FromBody] CompanyDto company)
        {
            try
            {
                var isAdded = CompanyServices.Addcompany(company);
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


    }
}
