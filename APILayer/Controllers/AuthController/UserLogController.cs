using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using APILayer.Auth;
using BLL.DTOs;
using BLL.Services;

namespace APILayer.Controllers.AuthController
{
    public class UserLogController : ApiController
    {
        [HttpPost]
        [Route("api/auth/login")]
        public IHttpActionResult Login([FromBody] LoginDto loginDto)
        {
            try
            {
                var token = AuthService.Authenticate(loginDto.Email, loginDto.Password);
                return ResponseMessage(token == null
                    ? Request.CreateResponse(HttpStatusCode.NotFound)
                    : Request.CreateResponse(HttpStatusCode.OK, token));
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.BadRequest, e.Message));
            }
        }

        [HttpPost]
        [Route("api/auth/token")]
        public IHttpActionResult IsTokenValid([FromBody] TokenDTO token)
        {
            try
            {
                var isValid = AuthService.IsTokenValid(token.TKey);
                return ResponseMessage(isValid
                    ? Request.CreateResponse(HttpStatusCode.OK)
                    : Request.CreateResponse(HttpStatusCode.NotFound));
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.BadRequest, e.Message));
            }
        }

        [HttpPost]
        [Route("api/auth/user")]
        public IHttpActionResult GetUserByToken([FromBody] TokenDTO token)
        {
            try
            {
                var user = AuthService.GetAuthUserDto(token.TKey);
                return ResponseMessage(user == null
                    ? Request.CreateResponse(HttpStatusCode.NotFound)
                    : Request.CreateResponse(HttpStatusCode.OK, user));
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.BadRequest, e.Message));
            }
        }

        [HttpGet]
        [Logged]
        [Route("api/auth/logout")]
        public IHttpActionResult Logout()
        {
            try
            {
                var token = Request.Headers.Authorization;
                var isLogout = AuthService.Logout(token.ToString());
                return ResponseMessage(isLogout
                    ? Request.CreateResponse(HttpStatusCode.OK)
                    : Request.CreateResponse(HttpStatusCode.NotFound));
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.BadRequest, e.Message));
            }
        }
    }
}