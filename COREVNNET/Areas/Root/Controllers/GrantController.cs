using COREVNNET.Areas.Root.Models.BusinessModels;
using COREVNNET.Areas.Root.Models.DataModels;
using COREVNNET.Areas.Root.Models.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace COREVNNET.Areas.Root.Controllers
{
    [AttributeForAction]
    public class GrantController : Controller
    {

        private CorevnNetContext db = new CorevnNetContext();
        // GET: Admin/Grant
        public ActionResult Index(int id)
        {
            //lấy tất cả các nghiệp vụ (controller) trong csdl
            var listcontrol = db.Business.AsEnumerable();
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (var item in listcontrol)
            {
                items.Add(new SelectListItem() { Text = item.BusinessName, Value = item.BusinessId });
            }
            ViewBag.items = items;
            // lấy danh sách các quyền đã được cấp
            var list = db.GrantPermission.Join(db.Permission, g => g.PermissionId, p => p.PermissionId,
                (g, p) => new { Permission = p, GrantPermission = g }).
                Where(x => x.GrantPermission.UserId == id).AsEnumerable();
            List<SelectListItem> listGranted = new List<SelectListItem>();
            foreach (var item in list)
            {
                listGranted.Add(new SelectListItem() { Value = item.Permission.PermissionId.ToString(), Text = item.Permission.Description });
            }
            ViewBag.listGranted = listGranted;
            //lưu id của người dùng đang được câp ra session
            Session["usergrant"] = id;
            //lấy người dùng
            var usergrant = db.Administrator.Find(id);
            //lưu tên ra biến
            ViewBag.usergrant = usergrant.Username + "(" + usergrant.FullName + ")";
            ViewBag.usergrantimg = usergrant.Avatar;
            return View();
        }
        public JsonResult getPermissions(string id, int usertemp)
        {
            var listgranted = db.GrantPermission.Join(db.Permission, g => g.PermissionId, p => p.PermissionId
            , (g, p) => new PermissionAciton
            {
                PermissionId = p.PermissionId,
                PermissionName = p.PermissionName,
                Description = p.Description,
                IsGranted = true
            }
            ).ToList();

            // lấy tất cả các quyền của business hiện tại
            var listpermission = db.Permission.Where(x => x.BusinessId == id).Select(x => new PermissionAciton
            {
                PermissionId = x.PermissionId,
                PermissionName = x.PermissionName,
                Description = x.Description,
                IsGranted = false
            });
            //lay id cua permission da duoc gan o tren cho nguoi dung
            var listpermissionId = listgranted.Select(x => x.PermissionId);

            foreach (var item in listpermission)
            {
                if (!listpermissionId.Contains(item.PermissionId))
                {
                    listgranted.Add(item);
                }
            }
            return Json(listgranted.OrderBy(x => x.Description), JsonRequestBehavior.AllowGet);
        }
        public string updatePermission(int id, int usertemp)
        {
            string msg = "";
            var grant = db.GrantPermission.Find(id, usertemp);
            if (grant == null)
            {
                GrantPermission g = new GrantPermission() { PermissionId = id, UserId = usertemp, Description = "" };
                db.GrantPermission.Add(g);
                msg = "<div class ='alert alert-success'>Quyền cấp thành công</div>";
            }
            else
            {
                db.GrantPermission.Remove(grant);
                msg = "<div class = 'alert alert-danger'>Hủy quyền thành công</div>";
            }
            db.SaveChanges();
            return msg;
        }

    }

}