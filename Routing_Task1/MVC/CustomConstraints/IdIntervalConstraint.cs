using System.Web;
using System.Web.Routing;

namespace MVC.CustomConstraints
{
    public class IdIntervalConstraint : IRouteConstraint
    {
        public IdIntervalConstraint()
        {

        }

        public bool Match
            (
                HttpContextBase httpContext,
                Route route, 
                string parameterName,
                RouteValueDictionary values,
                RouteDirection routeDirection
            )
        {
            string stringData = values[parameterName].ToString();

            if (stringData == "")
            {
                return false;
            }

            int data;

            if (!(int.TryParse(stringData, out data)))
            {
                return false;
            }

            return (data > 0 && data < 100);
        }
    }
}