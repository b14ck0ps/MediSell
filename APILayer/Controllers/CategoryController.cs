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
    public class CategoryController : ApiController
    {
        [HttpGet]
        [Route("api/categories")]
        public IHttpActionResult Get()
        {
            try
            {
                var categories = CategoryServices.GetAllCategory();
                return ResponseMessage(categories == null
                    ? Request.CreateResponse(HttpStatusCode.NotFound)
                    : Request.CreateResponse(HttpStatusCode.OK, categories));
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.BadRequest, e.Message));
            }
        }

        [HttpPost]
        [Route("api/category")]
        public IHttpActionResult Post([FromBody] CategoryDto category)
        {
            try
            {
                var isAdded = CategoryServices.AddCategory(category);
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
        [HttpGet]
        [Route("api/category/{id}")]
        public IHttpActionResult Get(int id)
        {
            try
            {
                var category = CategoryServices.GetCategoryById(id);
                return ResponseMessage(category == null
                    ? Request.CreateResponse(HttpStatusCode.NotFound)
                    : Request.CreateResponse(HttpStatusCode.OK, category));
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.BadRequest, e.Message));
            }
        }
        [HttpPatch]
        [Route("api/category")]
        public IHttpActionResult Patch([FromBody] CategoryDto category)
        {
            try
            {
                var isUpdated = CategoryServices.UpdateCategory(category);
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
    }
}
