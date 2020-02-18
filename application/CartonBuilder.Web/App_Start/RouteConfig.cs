using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CartonBuilder.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // Prettify carton command routes.
            // Instead of 'Carton/ListAvailableEquipment/5', specify route as 'Carton/5/ListAvailableEquipment'.
            routes.MapRoute(
                name: "CartonCommand",
                url: "Carton/{id}/{action}",
                defaults: new { controller = "Carton" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Carton", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
