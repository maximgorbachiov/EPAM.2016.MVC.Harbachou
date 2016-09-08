
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Routing;
using Machine.Specifications;
using Moq;
using MVC;
using It = Machine.Specifications.It;

namespace Tests
{
    public static class TestHelper
    {
        public static RouteData GetRouteData(string url)
        {
            var routes = new RouteCollection();
            var httpContext = new Mock<HttpContextBase>();

            RouteConfig.RegisterRoutes(routes);

            httpContext.Setup(x => x.Request.AppRelativeCurrentExecutionFilePath).Returns(url);

            return routes.GetRouteData(httpContext.Object);
        }

        public static bool CompareResults(RouteData routeData, string controller, string action, string id = null)
        {
            var isIdMatch = true;

            if (id != null)
            {
                isIdMatch = Compare(routeData.Values["id"].ToString(), id);
            }

            return isIdMatch &&
                   Compare(routeData.Values["controller"].ToString(), controller) &&
                   Compare(routeData.Values["action"].ToString(), action);
        }

        private static bool Compare(string a, string b) =>
            StringComparer.InvariantCultureIgnoreCase.Compare(a, b) == 0;

    }

    [Subject("Default route")]
    public class When_route_is_empty
    {
        private static RouteData routeData;

        Establish context = () => routeData = new RouteData();

        Because of = () => routeData = TestHelper.GetRouteData("~/");

        It should_be_Home_Index = () =>
            TestHelper.CompareResults(routeData, "Home", "Index").ShouldBeTrue();
    }

    [Subject("Custom route")]
    public class When_route_is_custom
    {
        private static RouteData routeData;

        Establish context = () => routeData = new RouteData();

        Because of = () => routeData = TestHelper.GetRouteData("~/Custom/Index/6");

        It should_be_Custom_Index_6 = () =>
            TestHelper.CompareResults(routeData, "Custom", "Index", "6").ShouldBeTrue();
    }

    [Subject("Static route")]
    public class When_route_is_static
    {
        private static RouteData routeData;

        Establish context = () => routeData = new RouteData();

        Because of = () => routeData = TestHelper.GetRouteData("~/Static/dog");
         
        It should_be_Custom_Index_6 = () =>
            TestHelper.CompareResults(routeData, "Custom", "Index", "dog").ShouldBeTrue();
    }

    [Subject("Custom route: custom constraints")]
    public class When_route_has_id_which_verified_by_custom_constraint_on_interval_id_from_1_to_100
    {
        private static RouteData routeData;

        Establish context = () => routeData = new RouteData();

        Because of = () => routeData = TestHelper.GetRouteData("~/Custom/Index/5");

        It should_not_be_Custom_Index_5 = () =>
            TestHelper.CompareResults(routeData, "Custom", "Index", "5").ShouldBeTrue();
    }

    [Subject("Static route: base constraints")]
    public class When_route_has_id_which_verified_by_base_constraint_on_minlength_3_and_maxlength_6
    {
        private static RouteData routeData;

        Establish context = () => routeData = new RouteData();

        Because of = () => routeData = TestHelper.GetRouteData("~/Static/hello");

        It should_not_be_Custom_Index_hello = () =>
            TestHelper.CompareResults(routeData, "Custom", "Index", "hello").ShouldBeTrue();
    }
}
