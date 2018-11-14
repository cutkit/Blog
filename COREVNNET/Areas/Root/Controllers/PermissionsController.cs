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
    public class PermissionsController : Controller
    {
        private CorevnNetContext db = new CorevnNetContext();

        // GET: Root/Permissions
        public ActionResult Index(string id)
        {
            var permission = db.Permission.Where(x => x.BusinessId == id);
            return View(permission.ToList());
        }

        // GET: Root/Permissions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Permission permission = db.Permission.Find(id);
            if (permission == null)
            {
                return HttpNotFound();
            }
            return View(permission);
        }

        // GET: Root/Permissions/Create
        public ActionResult Create()
        {
            ViewBag.BusinessId = new SelectList(db.Business, "BusinessId", "BusinessName");
            return View();
        }

        // POST: Root/Permissions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PermissionId,PermissionName,Description,BusinessId")] Permission permission)
        {
            if (ModelState.IsValid)
            {
                db.Permission.Add(permission);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BusinessId = new SelectList(db.Business, "BusinessId", "BusinessName", permission.BusinessId);
            return View(permission);
        }

        // GET: Root/Permissions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Permission permission = db.Permission.Find(id);
            if (permission == null)
            {
                return HttpNotFound();
            }
            ViewBag.BusinessId = new SelectList(db.Business, "BusinessId", "BusinessName", permission.BusinessId);
            return View(permission);
        }

        // POST: Root/Permissions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PermissionId,PermissionName,Description,BusinessId")] Permission permission)
        {
            if (ModelState.IsValid)
            {
                db.Entry(permission).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BusinessId = new SelectList(db.Business, "BusinessId", "BusinessName", permission.BusinessId);
            return View(permission);
        }

        // GET: Root/Permissions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Permission permission = db.Permission.Find(id);
            if (permission == null)
            {
                return HttpNotFound();
            }
            return View(permission);
        }

        // POST: Root/Permissions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Permission permission = db.Permission.Find(id);
            db.Permission.Remove(permission);
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
