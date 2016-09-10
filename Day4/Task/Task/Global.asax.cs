using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Task.Infrastructure;
using Task.Models;

namespace Task
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            ModelBinders.Binders.Add(typeof(Address), new AddressModelBinder());
            ModelBinders.Binders.Add(typeof(User), new UserModelBinder());
        }
    }
}
