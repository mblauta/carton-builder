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

            // Special route so we can have clean URLs.
            // Instead of '/Carton/AddEquipment/5?cartonId=5&equipmentId=9', specify route as '/Carton/5/AddEquipment/9'
            routes.MapRoute(
                name: "CartonOperationWithEquipment",
                url: "Carton/{cartonId}/{action}/{equipmentId}",
                defaults: new { controller = "Carton" }
            );

            // Prettify carton command routes.
            // Instead of 'Carton/ListAvailableEquipment/5', specify route as 'Carton/5/ListAvailableEquipment'.
            routes.MapRoute(
                name: "CartonOperation",
                url: "Carton/{cartonId}/{action}",
                defaults: new { controller = "Carton" }
            );

            // Default route...
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Carton", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
