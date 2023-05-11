﻿using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using BLL.Services;

namespace APILayer.Auth
{
    public class AdminAccess : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            var token = actionContext.Request.Headers.Authorization?.Parameter;
            if (token == null || !AuthService.IsTokenValid(token) || !AuthService.IsAdmin(token))
            {
                actionContext.Response = actionContext.Request.CreateResponse(System.Net.HttpStatusCode.Unauthorized);
                return;
            }

            base.OnAuthorization(actionContext);
        }
    }
}