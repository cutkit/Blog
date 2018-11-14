using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Data.Entity;
using COREVNNET.Areas.Root.Models.BusinessModels;
using COREVNNET.Areas.Root.Models.DataModels;

namespace COREVNNET
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            Database.SetInitializer(new CoreVnDatabaseInitializer());
           
        }
        protected void Session_Start()
        {
            Session["userid"] = null;
            Session["username"] = null;
            Session["fullname"] = null;
            Session["email"] = null;
            Session["password"] = null;
            Session["avatar"] = null;

            int cnt = Convert.ToInt32(Application["countvisitor"]) +1;
            Application["countvisitor"] = cnt;
            Session["countvisitor"] = cnt;
            CorevnNetContext db = new CorevnNetContext();
            var adcnt = db.Counter.FirstOrDefault();
            adcnt.CountVisitor = adcnt.CountVisitor + 1;
            Session["countvisitor"] = adcnt.CountVisitor + 1;
            db.SaveChanges();

        }
        
      
    }
}
