using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace COREVNNET.Areas.Root.Models.BusinessModels
{
    public class AttributeForAction: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (HttpContext.Current.Session["userid"] == null)
            {
                filterContext.Result = new RedirectResult("/Root/Home/Login?returnUrl=/Admin/" + filterContext.ActionDescriptor.ControllerDescriptor.ControllerName + "/" + filterContext.ActionDescriptor.ActionName);
                return;
            }
            else
            {
                int userId = int.Parse(HttpContext.Current.Session["userid"].ToString());
                //lay ten action
                string actionName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName + "Controller-" + filterContext.ActionDescriptor.ActionName;
                CorevnNetContext db = new CorevnNetContext();
                //lay thong tin user
                var admin = db.Administrator.Where(x => x.UserId == userId && x.IsAdmin == 1).FirstOrDefault();
                if (admin != null)
                {
                    return;
                }
                else
                {
                    //var listpermission = from p in db.Permission
                    //                     join g in db.GrantPermission on p.PermissionId equals g.PermissionId
                    //                     where g.UserId == userId
                    //                     select p.PermissionName;
                    var listpermission = db.Permission.Join(db.GrantPermission,
                        p => p.PermissionId, g => g.PermissionId, (p, g) =>
                             new { Permission = p, GrantPermission = g }).
                             Where(x => x.GrantPermission.UserId == userId).Select(x => x.Permission.PermissionName);

                    if (!listpermission.Contains(actionName))
                    {
                        filterContext.Result = new RedirectResult("/Root/Home/ActionError");
                        return;
                    }
                }
            }
        }
    }
}