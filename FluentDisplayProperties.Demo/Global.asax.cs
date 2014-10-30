﻿using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using FluentDisplayProperties.Demo.Configuration;
using FluentDisplayProperties.MetaData;
using DisplayProperties = FluentDisplayProperties.MetaData.FluentDisplayProperties;

namespace FluentDisplayProperties.Demo
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            var res = new ExampleModelProperties();
            DisplayProperties.Register();

            ModelMetadataProviders.Current = new FluentDisplayPropertiesProvider();
        }
    }
}