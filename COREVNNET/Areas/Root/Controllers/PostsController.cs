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
    public class PostsController : Controller
    {
        private CorevnNetContext db = new CorevnNetContext();

        // GET: Root/Posts
        public ActionResult Index()
        {
            var post = db.Post.Include(p => p.Administrator).Include(p => p.Category);
            return View(post.ToList());
        }

        // GET: Root/Posts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Post.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // GET: Root/Posts/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.Administrator, "UserId", "Username");
            ViewBag.CategoryId = new SelectList(db.Category, "CategoryId", "CategoryName");
            return View();
        }

        // POST: Root/Posts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PostId,CategoryId,UserId,Title,Brief,Content,Picture,DateCreate,Tags,ViewNo,Status")] Post post)
        {
            if (ModelState.IsValid)
            {
                db.Post.Add(post);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.Administrator, "UserId", "Username", post.UserId);
            ViewBag.CategoryId = new SelectList(db.Category, "CategoryId", "CategoryName", post.CategoryId);
            return View(post);
        }

        // GET: Root/Posts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Post.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.Administrator, "UserId", "Username", post.UserId);
            ViewBag.CategoryId = new SelectList(db.Category, "CategoryId", "CategoryName", post.CategoryId);
            return View(post);
        }

        // POST: Root/Posts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PostId,CategoryId,UserId,Title,Brief,Content,Picture,DateCreate,Tags,ViewNo,Status")] Post post)
        {
            if (ModelState.IsValid)
            {
                db.Entry(post).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.Administrator, "UserId", "Username", post.UserId);
            ViewBag.CategoryId = new SelectList(db.Category, "CategoryId", "CategoryName", post.CategoryId);
            return View(post);
        }

        // GET: Root/Posts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Post.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // POST: Root/Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Post post = db.Post.Find(id);
            db.Post.Remove(post);
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
