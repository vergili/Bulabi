using bulabi.Domain.Entities;
using bulabi.WebUI.Infrastructure;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Data.Entity;
using System.Web;
using System;

namespace bulabi.WebUI
{

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {

            Database.SetInitializer<DbContext>(null);


            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory());

            //ModelBinders.Binders.Add(typeof(Cart), new CartModelBinder());

            //Get the IP Adddress of the host to send for the licensing service
            //var domainUrl = HttpContext.Current.Request.ServerVariables["LOCAL_ADDR"];
          
        }


    }
}