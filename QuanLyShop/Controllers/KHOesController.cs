using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QuanLyShop.Models;

namespace QuanLyShop.Controllers
{
    public class KHOesController : Controller
    {
        private de_an_web_ver7Entities db = new de_an_web_ver7Entities();

        // GET: KHOes
        public ActionResult Index()
        {
            var kHOes = db.KHOes.Include(k => k.NSX);
            return View(kHOes.ToList());
        }

        // GET: KHOes/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KHO kHO = db.KHOes.Find(id);
            if (kHO == null)
            {
                return HttpNotFound();
            }
            return View(kHO);
        }

        // GET: KHOes/Create
        public ActionResult Create()
        {
            ViewBag.MaNSX = new SelectList(db.NSXes, "MaNSX", "TenNSX");
            return View();
        }

        // POST: KHOes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaLoHang,MaNSX,TenLoHang,SoLuong,NgayNhap")] KHO kHO)
        {
            if (ModelState.IsValid)
            {
                db.KHOes.Add(kHO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaNSX = new SelectList(db.NSXes, "MaNSX", "TenNSX", kHO.MaNSX);
            return View(kHO);
        }

        // GET: KHOes/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KHO kHO = db.KHOes.Find(id);
            if (kHO == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaNSX = new SelectList(db.NSXes, "MaNSX", "TenNSX", kHO.MaNSX);
            return View(kHO);
        }

        // POST: KHOes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaLoHang,MaNSX,TenLoHang,SoLuong,NgayNhap")] KHO kHO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kHO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaNSX = new SelectList(db.NSXes, "MaNSX", "TenNSX", kHO.MaNSX);
            return View(kHO);
        }

        // GET: KHOes/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KHO kHO = db.KHOes.Find(id);
            if (kHO == null)
            {
                return HttpNotFound();
            }
            return View(kHO);
        }

        // POST: KHOes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            KHO kHO = db.KHOes.Find(id);
            db.KHOes.Remove(kHO);
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
