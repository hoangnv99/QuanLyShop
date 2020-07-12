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
    public class QUANAOsController : Controller
    {
        private de_an_web_ver7Entities db = new de_an_web_ver7Entities();

        // GET: QUANAOs
        public ActionResult Index()
        {
            var qUANAOs = db.QUANAOs.Include(q => q.KHO);
            return View(qUANAOs.ToList());
        }

        // GET: QUANAOs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QUANAO qUANAO = db.QUANAOs.Find(id);
            if (qUANAO == null)
            {
                return HttpNotFound();
            }
            return View(qUANAO);
        }

        // GET: QUANAOs/Create
        public ActionResult Create()
        {
            ViewBag.MaLoHang = new SelectList(db.KHOes, "MaLoHang", "MaNSX");
            return View();
        }

        // POST: QUANAOs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaQA,MaLoHang,TenQuanAo,Size,GiaSanPham,MauSac,AnhMinhHoa,NoiSX")] QUANAO qUANAO)
        {
            if (ModelState.IsValid)
            {
                db.QUANAOs.Add(qUANAO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaLoHang = new SelectList(db.KHOes, "MaLoHang", "MaNSX", qUANAO.MaLoHang);
            return View(qUANAO);
        }

        // GET: QUANAOs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QUANAO qUANAO = db.QUANAOs.Find(id);
            if (qUANAO == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaLoHang = new SelectList(db.KHOes, "MaLoHang", "MaNSX", qUANAO.MaLoHang);
            return View(qUANAO);
        }

        // POST: QUANAOs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaQA,MaLoHang,TenQuanAo,Size,GiaSanPham,MauSac,AnhMinhHoa,NoiSX")] QUANAO qUANAO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(qUANAO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaLoHang = new SelectList(db.KHOes, "MaLoHang", "MaNSX", qUANAO.MaLoHang);
            return View(qUANAO);
        }

        // GET: QUANAOs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QUANAO qUANAO = db.QUANAOs.Find(id);
            if (qUANAO == null)
            {
                return HttpNotFound();
            }
            return View(qUANAO);
        }

        // POST: QUANAOs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            QUANAO qUANAO = db.QUANAOs.Find(id);
            db.QUANAOs.Remove(qUANAO);
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
