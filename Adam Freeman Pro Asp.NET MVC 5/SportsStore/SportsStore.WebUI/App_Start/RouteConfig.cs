using System.Web.Mvc;
using System.Web.Routing;

namespace SportsStore.WebUI
{
    public class RouteConfig
    {
      public static void RegisterRoutes(RouteCollection routes)
      {
        routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

        // name / url / defaults
        // for / url
        routes.MapRoute(null, "",
          new
          {
            controller = "Product",
            action = "List",
            category = (string) null,
            page = 1
          }
          );

        // for /Page2 url
        routes.MapRoute(null, "Page{page}",
          new
          {
            controller = "Product",
            action = "List",
            category =
              (string) null
          },
          new {page = @"\d+"}
          );

        // for /Soccer url
        routes.MapRoute(null, "{category}",
          new {controller = "Product", action = "List", page = 1}
          );

        // for /Soccer/Page2 url
        routes.MapRoute(null, "{category}/Page{page}",
          new {controller = "Product", action = "List"},
          new {page = @"\d+"}
          );

        routes.MapRoute(null, "{controller}/{action}");
      }
    }
}
