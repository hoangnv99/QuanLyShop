using QuanLyShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace QuanLyShop.Controllers
{
    public class TongController : Controller
    {
        private de_an_web_ver7Entities db = new de_an_web_ver7Entities();
        // GET: Tong
       

        public bool CheckUser(string username, string password)
        {
            var kq = db.QUANTRIs.Where(x => x.Email == username && x.Password == password).ToList();
            //string hoTen = kq.First().HoTen;
            if (kq.Count() > 0)
            {
                Session["HoTen"] = kq.First().HoTen;
                return true;
            }
            else
            {
                Session["HoTen"] = null;
                return false;
            }
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(QUANTRI qt)
        {
            if (ModelState.IsValid)
            {
                if (CheckUser(qt.Email, qt.Password))
                {
                    FormsAuthentication.SetAuthCookie(qt.Email, true);
                    return RedirectToAction("index", "Tong/TrangChu");
                }
                else
                    ModelState.AddModelError("index", "Tên đăng nhập hoặc tài khoản không đúng.");

            }
            return View(qt);
        }
        public ActionResult single()
        {

            return View("single");
        }
        public ActionResult TrangChu()
        {

            return View("TrangChu");
        }
        public ActionResult about()
        {

            return View("about");
        }
        public ActionResult mens()
        {

            return View("mens");
        }
        public ActionResult index()
        {

            return View("index");
        }
    }
}