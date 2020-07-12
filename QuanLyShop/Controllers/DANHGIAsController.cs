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
    public class DANHGIAsController : Controller
    {
        private de_an_web_ver7Entities db = new de_an_web_ver7Entities();

        // GET: DANHGIAs
        public ActionResult Index()
        {
            var dANHGIAs = db.DANHGIAs.Include(d => d.KHACHHANG).Include(d => d.QUANAO);
            return View(dANHGIAs.ToList());
        }

        // GET: DANHGIAs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DANHGIA dANHGIA = db.DANHGIAs.Find(id);
            if (dANHGIA == null)
            {
                return HttpNotFound();
            }
            return View(dANHGIA);
        }

        // GET: DANHGIAs/Create
        public ActionResult Create()
        {
            ViewBag.MaKH = new SelectList(db.KHACHHANGs, "MaKH", "HoTen");
            ViewBag.MaQA = new SelectList(db.QUANAOs, "MaQA", "MaLoHang");
            return View();
        }

        // POST: DANHGIAs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaDG,MaKH,MaQA,NgayDG,DanhGia1")] DANHGIA dANHGIA)
        {
            if (ModelState.IsValid)
            {
                db.DANHGIAs.Add(dANHGIA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaKH = new SelectList(db.KHACHHANGs, "MaKH", "HoTen", dANHGIA.MaKH);
            ViewBag.MaQA = new SelectList(db.QUANAOs, "MaQA", "MaLoHang", dANHGIA.MaQA);
            return View(dANHGIA);
        }

        // GET: DANHGIAs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DANHGIA dANHGIA = db.DANHGIAs.Find(id);
            if (dANHGIA == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaKH = new SelectList(db.KHACHHANGs, "MaKH", "HoTen", dANHGIA.MaKH);
            ViewBag.MaQA = new SelectList(db.QUANAOs, "MaQA", "MaLoHang", dANHGIA.MaQA);
            return View(dANHGIA);
        }

        // POST: DANHGIAs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaDG,MaKH,MaQA,NgayDG,DanhGia1")] DANHGIA dANHGIA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dANHGIA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaKH = new SelectList(db.KHACHHANGs, "MaKH", "HoTen", dANHGIA.MaKH);
            ViewBag.MaQA = new SelectList(db.QUANAOs, "MaQA", "MaLoHang", dANHGIA.MaQA);
            return View(dANHGIA);
        }

        // GET: DANHGIAs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DANHGIA dANHGIA = db.DANHGIAs.Find(id);
            if (dANHGIA == null)
            {
                return HttpNotFound();
            }
            return View(dANHGIA);
        }

        // POST: DANHGIAs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            DANHGIA dANHGIA = db.DANHGIAs.Find(id);
            db.DANHGIAs.Remove(dANHGIA);
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
