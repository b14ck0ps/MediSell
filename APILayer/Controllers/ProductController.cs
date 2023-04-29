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
    public class ProductController : ApiController
    {
        [HttpPost]
        [Route("api/product")]
        public IHttpActionResult AddProduct([FromBody] ProductDto product)
        {
            try
            {
                var result = ProductServices.AddProduct(product);
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, result));
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message));
            }
        }
        [HttpGet]
        [Route("api/products")]
        public IHttpActionResult GetAllProducts()
        {
            try
            {
                var products = ProductServices.GetAllProducts();
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, products));
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message));
            }
        }

        [HttpGet]
        [Route("api/product/{id}")]
        public IHttpActionResult GetProductById(int id)
        {
            try
            {
                var product = ProductServices.GetProductById(id);
                return ResponseMessage(product == null
                    ? Request.CreateResponse(HttpStatusCode.NotFound)
                    : Request.CreateResponse(HttpStatusCode.OK, product));
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message));
            }
        }
        [HttpGet]
        [Route("api/product/company/{id}")]
        public IHttpActionResult GetAllProductsByCompanyId(int id)
        {
            try
            {
                var products = ProductServices.GetAllProductsByCompanyId(id);
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, products));
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message));
            }
        }
        [HttpGet]
        [Route("api/product/category/{id}")]
        public IHttpActionResult GetAllProductsByCategoryId(int id)
        {
            try
            {
                var products = ProductServices.GetAllProductsByCategoryId(id);
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, products));
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message));
            }
        }
        [HttpPut]
        [Route("api/product")]
        public IHttpActionResult UpdateProduct([FromBody] ProductDto product)
        {
            try
            {
                var result = ProductServices.UpdateProduct(product);
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, result));
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message));
            }
        }
        [HttpDelete]
        [Route("api/product/{id}")]
        public IHttpActionResult DeleteProduct(int id)
        {
            try
            {
                var result = ProductServices.DeleteProduct(id);
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, result));
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message));
            }
        }
    }
}
