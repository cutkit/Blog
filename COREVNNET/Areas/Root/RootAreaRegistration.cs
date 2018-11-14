using System.Web.Mvc;

namespace COREVNNET.Areas.Root
{
    public class RootAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Root";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Root_default",
                "Root/{controller}/{action}/{id}",
                new { Controller = "Home", action = "Index", id = UrlParameter.Optional },
                new string[] { "COREVNNET.Areas.Root.Controllers" }
            );
        }
    }
}