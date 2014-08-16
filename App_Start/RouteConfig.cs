using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using bulabi.WebUI.HtmlHelpers;

namespace bulabi.WebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(null, "",
                new
                {
                    controller = "Product",
                    action = "List",
                    //category = null,
                    //country = "TR",
                    //publishsection = "web",
                    timeperiod = "today",
                    page = 1
                }
            );

            routes.MapRoute(null, "{controller}/{action}" );

            //routes.MapRoute(null, "{controller}/{action}");


        }
    }


}