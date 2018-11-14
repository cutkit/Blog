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
    public class GrantPermissionsController : Controller
    {
        private CorevnNetContext db = new CorevnNetContext();

        // GET: Root/GrantPermissions
        public ActionResult Index()
        {
            var grantPermission = db.GrantPermission.Include(g => g.Administrator).Include(g => g.Permission);
            return View(grantPermission.ToList());
        }

        // GET: Root/GrantPermissions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GrantPermission grantPermission = db.GrantPermission.Find(id);
            if (grantPermission == null)
            {
                return HttpNotFound();
            }
            return View(grantPermission);
        }

        // GET: Root/GrantPermissions/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.Administrator, "UserId", "Username");
            ViewBag.PermissionId = new SelectList(db.Permission, "PermissionId", "PermissionName");
            return View();
        }

        // POST: Root/GrantPermissions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PermissionId,UserId,Description")] GrantPermission grantPermission)
        {
            if (ModelState.IsValid)
            {
                db.GrantPermission.Add(grantPermission);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.Administrator, "UserId", "Username", grantPermission.UserId);
            ViewBag.PermissionId = new SelectList(db.Permission, "PermissionId", "PermissionName", grantPermission.PermissionId);
            return View(grantPermission);
        }

        // GET: Root/GrantPermissions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GrantPermission grantPermission = db.GrantPermission.Find(id);
            if (grantPermission == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.Administrator, "UserId", "Username", grantPermission.UserId);
            ViewBag.PermissionId = new SelectList(db.Permission, "PermissionId", "PermissionName", grantPermission.PermissionId);
            return View(grantPermission);
        }

        // POST: Root/GrantPermissions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PermissionId,UserId,Description")] GrantPermission grantPermission)
        {
            if (ModelState.IsValid)
            {
                db.Entry(grantPermission).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.Administrator, "UserId", "Username", grantPermission.UserId);
            ViewBag.PermissionId = new SelectList(db.Permission, "PermissionId", "PermissionName", grantPermission.PermissionId);
            return View(grantPermission);
        }

        // GET: Root/GrantPermissions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GrantPermission grantPermission = db.GrantPermission.Find(id);
            if (grantPermission == null)
            {
                return HttpNotFound();
            }
            return View(grantPermission);
        }

        // POST: Root/GrantPermissions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GrantPermission grantPermission = db.GrantPermission.Find(id);
            db.GrantPermission.Remove(grantPermission);
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
