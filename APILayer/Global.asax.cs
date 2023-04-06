using System;
using System.Web;
using System.Web.Http;
using AutoMapper;
using BLL.DTOs;

namespace APILayer
{
    public class WebApiApplication : HttpApplication
    {
        [Obsolete("Obsolete")]
        protected void Application_Start()
        {
            Mapper.Initialize(cfg => cfg.AddProfile<AutoMapperProfile>());
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}