using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using COREVNNET.Areas.Root.Models.BusinessModels;
using COREVNNET.Areas.Root.Models.DataModels;

namespace COREVNNET.Areas.Root.Controllers
{
    [AttributeForAction]
    public class BusinessesController : Controller
    {
        private CorevnNetContext db = new CorevnNetContext();

        //cập nhật controller
        public ActionResult Update()
        {
            Reflection rc = new Reflection();
            List<Type> listControllerType = rc.GetControllers("COREVNNET.Areas.Root.Controllers");
            List<string> listControllerOld = db.Business.Select(c => c.BusinessId).ToList();
            List<string> listPermissionOld = db.Permission.Select(p => p.PermissionName).ToList();
            foreach (var c in listControllerType)
            {
                if (!listControllerOld.Contains(c.Name))
                {
                    Business b = new Business()
                    {
                        BusinessId = c.Name,
                        BusinessName = "Chưa có mô tả"
                    };
                    db.Business.Add(b);
                }
                List<string> listPermission = rc.GetAction(c);
                foreach (var p in listPermission)
                {
                    if (!listPermissionOld.Contains(c.Name + "-" + p))
                    {
                        Permission permission = new Permission()
                        {
                            PermissionName = c.Name + "-" + p,
                            Description = "Chưa có mô tả",
                            BusinessId = c.Name
                        };
                        db.Permission.Add(permission);
                    }
                }
            }
            db.SaveChanges();
            TempData["err"] = "<div class='alert alert-info' role='alert'><span class='glyphicon glyphicon-exclamation-sign' aria-hidden='true'></span><span class='sr-only'></span> Cập nhật thành công</div>";
            return RedirectToAction("Index");
        }
        // GET: Root/Businesses
        public ActionResult Index()
        {
            return View(db.Business.ToList());
        }

        // GET: Root/Businesses/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Business business = db.Business.Find(id);
            if (business == null)
            {
                return HttpNotFound();
            }
            return View(business);
        }

        // GET: Root/Businesses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Root/Businesses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BusinessId,BusinessName")] Business business)
        {
            if (ModelState.IsValid)
            {
                db.Business.Add(business);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(business);
        }

        // GET: Root/Businesses/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Business business = db.Business.Find(id);
            if (business == null)
            {
                return HttpNotFound();
            }
            return View(business);
        }

        // POST: Root/Businesses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BusinessId,BusinessName")] Business business)
        {
            if (ModelState.IsValid)
            {
                db.Entry(business).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(business);
        }

        // GET: Root/Businesses/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Business business = db.Business.Find(id);
            if (business == null)
            {
                return HttpNotFound();
            }
            return View(business);
        }

        // POST: Root/Businesses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Business business = db.Business.Find(id);
            db.Business.Remove(business);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
