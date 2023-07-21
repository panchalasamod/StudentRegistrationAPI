using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using TestStudentRegistration.Services.AutoMapper;

namespace TestStudentRegistration
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );


            var cors = new EnableCorsAttribute(origins: "*", headers: "*", methods: "GET, POST, PUT, DELETE, OPTIONS");
            config.EnableCors(cors);
            //[EnableCors(origins: "*", headers: "*", methods: "GET, POST, PUT, DELETE, OPTIONS")]

        }
    }
}
