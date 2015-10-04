using System.Web.Mvc;
using System.Web.Routing;

namespace CPro
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
               name: "Contact",
               url: "lien-he",
               defaults: new
               {
                   controller = "Contact",
                   action = "Index",
                   id = UrlParameter.Optional,

               },
                 namespaces: new[]
                {
                    "CPro.Controllers"
                }

           );
            routes.MapRoute(
              name: "About",
              url: "gioi-thieu",
              defaults: new
              {
                  controller = "About",
                  action = "Index",
                  id = UrlParameter.Optional,
              },
                namespaces: new[]
               {
                    "CPro.Controllers"
               }

          );
            routes.MapRoute(
               name: "Register",
               url: "dang-ky",
               defaults: new
               {
                   controller = "User",
                   action = "Register",
                   id = UrlParameter.Optional,
               },
                 namespaces: new[]
                {
                    "CPro.Controllers"
                }

           );
            routes.MapRoute(
              name: "Login",
              url: "dang-nhap",
              defaults: new
              {
                  controller = "User",
                  action = "Login",
                  id = UrlParameter.Optional,
              },
                namespaces: new[]
               {
                    "CPro.Controllers"
               }

          );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new
                {
                    controller = "Home", action = "Index", id = UrlParameter.Optional ,
                    
                },
                namespaces:new []
                {
                    "CPro.Controllers"
                }
            );
        }
    }
}
