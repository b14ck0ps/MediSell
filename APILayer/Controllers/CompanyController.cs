﻿using BLL.DTOs;
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
        //Get all company
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
        //Get Company by ID
        [HttpGet]
        [Route("api/company/{id}")]
        public IHttpActionResult Get(int id)
        {
            try
            {
                var company = CompanyServices.GetcompanyById(id);
                return ResponseMessage(company == null
                    ? Request.CreateResponse(HttpStatusCode.NotFound)
                    : Request.CreateResponse(HttpStatusCode.OK, company));
            }
            catch (Exception e)
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
        //Update Company
        [HttpPatch]
        [Route("api/company/update")]
        public IHttpActionResult Patch([FromBody] CompanyDto company)
        {
            try
            {
                var isUpdated = CompanyServices.Updatecompany(company);
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
        //Delete Company
        [HttpDelete]
        [Route("api/company/delete/{id}")]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                var isDeleted = CompanyServices.Deleteuser(id);
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