﻿using System.Web.Mvc;
using System.Web.Routing;
using FluentDisplayProperties.Demo.Configuration;
using FluentDisplayProperties.Registration;

namespace FluentDisplayProperties.Demo
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            // Register view model configurations to get added to collection
            ModelMetadataProviders.Current = PropertyRegistrar.Register(new MyRegistrationClass());
        }
    }
}