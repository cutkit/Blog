using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace COREVNNET
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            //routes.MapRoute(
            //   name: "trangchu",
            //   url: "trang-chu",
            //   defaults: new { controller = "Home", action = "Index" },
            //   namespaces: new string[] { "COREVNNET.Controllers" }
            //   );


            routes.MapRoute(
            name: "congnghe",
            url: "cong-nghe-va-thu-thuat",
            defaults: new { controller = "Home", action = "Tech" },
            namespaces: new string[] { "COREVNNET.Controllers" }

            );
            routes.MapRoute(
          name: "cuocsong",
          url: "cuoc-song",
          defaults: new { controller = "Home", action = "Life" },
          namespaces: new string[] { "COREVNNET.Controllers" }

          );
            routes.MapRoute(
       name: "ngichngom",
       url: "nghich-ngom",
       defaults: new { controller = "Home", action = "Naughty" },
       namespaces: new string[] { "COREVNNET.Controllers" }

       );
            routes.MapRoute(
                name: "gioithieu",
            url: "gioi-thieu",
             defaults: new { controller = "Home", action = "About" },
            namespaces: new string[] { "COREVNNET.Controllers" }

                );

            routes.MapRoute(
             name: "detail",
             url: "bai-viet/{title}-{id}",
             defaults: new { controller = "Home", action = "Detail" },
             namespaces: new string[] { "COREVNNET.Controllers" }

             );




            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "COREVNNET.Controllers" }
            );
        }
    }
}
