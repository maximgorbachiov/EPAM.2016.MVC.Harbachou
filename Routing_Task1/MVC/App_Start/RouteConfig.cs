using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using MVC.CustomConstraints;
using System.Web.Mvc.Routing.Constraints;
using System.Web.Mvc.Routing;

namespace MVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            /*routes.MapRoute(
                name: "Custom",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Custom", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "MVC.Controllers.CustomControllers" },
                constraints: new { id = new IdIntervalConstraint() }
            );

            routes.MapRoute(
                name: "Static",
                url: "Custom/{action}/{id}",
                defaults: new { controller = "Custom", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "MVC.Controllers.StaticControllers" },
                constraints: new { id = new CompoundRouteConstraint(
                    new IRouteConstraint[] 
                    {
                        new MinLengthRouteConstraint(3),
                        new MaxLengthRouteConstraint(6)
                    })
                }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );*/

            var constraintsResolver = new DefaultInlineConstraintResolver();

            constraintsResolver.ConstraintMap.Add("interval", typeof(IdIntervalConstraint));

            routes.MapMvcAttributeRoutes(constraintsResolver);

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
