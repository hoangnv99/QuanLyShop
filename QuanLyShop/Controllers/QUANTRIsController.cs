using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using QuanLyShop.Models;

namespace QuanLyShop.Controllers
{
    public class QUANTRIsController : Controller
    {
        private de_an_web_ver7Entities db = new de_an_web_ver7Entities();

        // GET: QUANTRIs
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
                    return RedirectToAction("Index", "QUANTRIs/Index");
                }
                else
                    ModelState.AddModelError("", "Tên đăng nhập hoặc tài khoản không đúng.");
            }
            return View(qt);
        }
        public ActionResult Index()
        {
            return View();
        }
            // GET: QUANTRIs/Details/5
            public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QUANTRI qUANTRI = db.QUANTRIs.Find(id);
            if (qUANTRI == null)
            {
                return HttpNotFound();
            }
            return View(qUANTRI);
        }

        // GET: QUANTRIs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: QUANTRIs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Email,Admin,HoTen,Password")] QUANTRI qUANTRI)
        {
            if (ModelState.IsValid)
            {
                db.QUANTRIs.Add(qUANTRI);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(qUANTRI);
        }

        // GET: QUANTRIs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QUANTRI qUANTRI = db.QUANTRIs.Find(id);
            if (qUANTRI == null)
            {
                return HttpNotFound();
            }
            return View(qUANTRI);
        }

        // POST: QUANTRIs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Email,Admin,HoTen,Password")] QUANTRI qUANTRI)
        {
            if (ModelState.IsValid)
            {
                db.Entry(qUANTRI).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(qUANTRI);
        }

        // GET: QUANTRIs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QUANTRI qUANTRI = db.QUANTRIs.Find(id);
            if (qUANTRI == null)
            {
                return HttpNotFound();
            }
            return View(qUANTRI);
        }

        // POST: QUANTRIs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            QUANTRI qUANTRI = db.QUANTRIs.Find(id);
            db.QUANTRIs.Remove(qUANTRI);
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
