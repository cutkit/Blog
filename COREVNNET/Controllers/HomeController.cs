using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using COREVNNET.Areas.Root.Models.BusinessModels;
using COREVNNET.Models.Query;
using COREVNNET.Areas.Root.Models.DataModels;
using PagedList;
using PagedList.Mvc;

namespace COREVNNET.Controllers
{
    public class HomeController : Controller
    {
        CorevnNetContext db = new CorevnNetContext();
        //Dem so luot truy cap
        //public ActionResult Visitor()
        //{
        //    //int tmpvisitor = 0;
        //    //var count = db.Counter.ToList();
        //    //foreach (var item in count)
        //    //{
        //    //    tmpvisitor = item.CountVisitor;
        //    //}
        //    //Session["countvisitor"] = tmpvisitor + 1;
        //    //int tmp = Convert.ToInt32(Session["countvisitor"]);
        //    //Counter ctremove = db.Counter.FirstOrDefault();
        //    //db.Counter.Remove(ctremove);
        //    //Counter moi = new Counter();
        //    //moi.CountVisitor = tmp; 
        //    //db.Counter.Add(moi);
        //    //db.SaveChanges();
        //    Counter ct  = db.Counter.FirstOrDefault();
        //    Session["countvisitor"] = ct.CountVisitor +1 ;
        //    ct.CountVisitor = ct.CountVisitor + 1;
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}
        public ActionResult Index(int? page)
        {

            ////dem so luot truy cap va so luot truy cap
            //Session["countvisitor"] = int.Parse(Session["countvisitor"].ToString()) + 1;
            //Session["countonline"] = Convert.ToInt32(Session["countonline"]) +1;

            //CorevnNetContext db = new CorevnNetContext();
            //int tmp = 0;
            //var count = db.Counter.ToList();
            //foreach (var item in count)
            //{
            //    tmp = item.CountVisitor;
            //}
            //Session["countvisitor"] = tmp +1;

            //int axx = Convert.ToInt32(Session["countvisitor"]);
            //Counter ctremove = db.Counter.FirstOrDefault();
            //db.Counter.Remove(ctremove);
            //Counter moi = new Counter();
            //moi.CountVisitor = axx;

            //db.Counter.Add(moi);
            //db.SaveChanges();



            //if (int.Parse(Session["Current"].ToString()) == 1)
            //{
            //Session["countvisitor"] = int.Parse(Session["countvisitor"].ToString()) + 1;
            //}
            //else
            //{
            //    Session["countvisitor"] = int.Parse(Session["countvisitor"].ToString()) -1 ;
            //}

            //Counter ctremove = db.Counter.Find(1);
            //db.Counter.Remove(ctremove);
            //Counter ctadd = new Counter();
            ////var tm = Session["countvisitor"];
            ////int unbox = (int)tm;
            //int tmp = 0;
            //ctadd.CountVisitor = tmp;
            //db.Counter.Add(ctadd);
            //db.SaveChanges();

            //var count = db.Counter.Where(x => x.CountId == 1).ToList();
            //List<Counter> listcount = count;
            //foreach (var item in listcount)
            //{
            //    //Session["countvisitor"] = item.CountVisitor +1;
            //    //Session["countonline"] = Session["countonline"] + 1;
            //    Session["countvisitor"] = item.CountVisitor;
            //    tmp = item.CountVisitor;
            //}

            // countonline = Session["countonline"];
            //var lispost = db.Posts.ToList();
            //tao bien so san pham tren trang
            int pageSize = 4;
            //ta bien so trang
            int pageNumber = (page ?? 1);

            var lispost = db.Post.Join(db.Administrator, p => p.UserId, a => a.UserId, (p, a) => new AdminVsPost
            { Administrator = a, Post = p }).OrderByDescending(x => x.Post.PostId).ToPagedList(pageNumber,pageSize);
            return View(lispost);
        }

        public ActionResult Detail(int id)
        {
            //
            int? tmp;
            List<Post> views = db.Post.Where(x => x.PostId == id).ToList();
            foreach (var item in views)
            {
                item.ViewNo = item.ViewNo + 1;
            }
            db.SaveChanges();
            var lisdetail = db.Post.Join(db.Administrator, p => p.UserId, a => a.UserId, (p, a) => new AdminVsPost
            { Administrator = a, Post = p }).Where(x => x.Post.PostId == id).ToList();
            return View(lisdetail);
        }
        public ActionResult Tech()
        {
            var listtech = db.Post.Join(db.Administrator, p => p.UserId, a => a.UserId, (p, a) => new AdminVsPost
            { Administrator = a, Post = p }).Where(x => x.Post.CategoryId == "A").ToList();
            return View(listtech);
        }
        public ActionResult Life()
        {
            var listlife = db.Post.Join(db.Administrator, p => p.UserId, a => a.UserId ,(p, a) => new  AdminVsPost
            { Administrator = a, Post = p}).Where(x => x.Post.CategoryId == "B").ToList();
            return View(listlife);
        }
        public ActionResult Naughty()
        {
            var listnaughty = db.Post.Join(db.Administrator, p => p.UserId, a => a.UserId, (p, a) => new AdminVsPost
            { Administrator = a, Post = p }).Where(x=>x.Post.CategoryId == "C").ToList();
            return View(listnaughty);
        }
        public ActionResult About()
        {
            var listabout = db.Post.Join(db.Administrator, p => p.UserId, a => a.UserId, (p, a) => new AdminVsPost
            { Administrator = a, Post = p }).Where(x => x.Post.CategoryId == "D").ToList();
            return View(listabout);
        }
        public PartialViewResult PanelRight()
        {
            //thay doi nho trong controller
           
            return PartialView();
        }
    }

}