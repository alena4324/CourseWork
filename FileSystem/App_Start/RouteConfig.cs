using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace FileSystem
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute(
            //    name: "DeleteItem",
            //    url: "{controller}/{adding}/{action}/{*path}",
            //    defaults: new { controller = "Directory", action = "AllD" }
            //);

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{*path}",
                defaults: new { controller = "Account", action = "Login" }
            );
        }
    }
}
