using COREVNNET.Areas.Root.Models.BusinessModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace COREVNNET.Areas.Root.Controllers
{
    public class HomeController : Controller
    {
        private CorevnNetContext db = new CorevnNetContext();
        // GET: Root/Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Signin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Signin(string username, string password)
        {
            string pw = Common.EncryptMD5(username + password);
            var user = db.Administrator.SingleOrDefault(x => x.Username == username && x.PassWord == pw && x.Allowed ==1);
            if (user != null)
            {
                Session["userid"] = user.UserId;
                Session["username"] = user.Username;
                Session["fullname"] = user.FullName;
                Session["email"] = user.Email;
                Session["password"] = user.PassWord;
                Session["avatar"] = user.Avatar;
                return RedirectToAction("Index");
            }
            ViewBag.error = "Sai Username Hoặc Password!!";
            return View();
        }
        public ActionResult Signout()
        {
            Session["userid"] = null;
            Session["username"] = null;
            Session["fullname"] = null;
            Session["email"] = null;
            Session["password"] = null;
            Session["avatar"] = null;
            return RedirectToAction("Signin");
        }
        public ActionResult ActionError()
        {
            return View();
        }
        //action request lai trang tranh chet session(timeout) -> script de o cuoi trang layout
        public EmptyResult Alive()
        {
            return new EmptyResult();
        }
    }
    
}