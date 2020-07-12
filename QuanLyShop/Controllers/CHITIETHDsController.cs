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
    public class CHITIETHDsController : Controller
    {
        private de_an_web_ver7Entities db = new de_an_web_ver7Entities();

        // GET: CHITIETHDs
        public ActionResult Index()
        {
            var cHITIETHDs = db.CHITIETHDs.Include(c => c.HOADON).Include(c => c.QUANAO);
            return View(cHITIETHDs.ToList());
        }

        // GET: CHITIETHDs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CHITIETHD cHITIETHD = db.CHITIETHDs.Find(id);
            if (cHITIETHD == null)
            {
                return HttpNotFound();
            }
            return View(cHITIETHD);
        }

        // GET: CHITIETHDs/Create
        public ActionResult Create()
        {
            ViewBag.MaHD = new SelectList(db.HOADONs, "MaHD", "MaKH");
            ViewBag.MaQA = new SelectList(db.QUANAOs, "MaQA", "MaLoHang");
            return View();
        }

        // POST: CHITIETHDs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaCTHD,MaHD,MaQA,SoLuong,DonGia")] CHITIETHD cHITIETHD)
        {
            if (ModelState.IsValid)
            {
                db.CHITIETHDs.Add(cHITIETHD);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaHD = new SelectList(db.HOADONs, "MaHD", "MaKH", cHITIETHD.MaHD);
            ViewBag.MaQA = new SelectList(db.QUANAOs, "MaQA", "MaLoHang", cHITIETHD.MaQA);
            return View(cHITIETHD);
        }

        // GET: CHITIETHDs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CHITIETHD cHITIETHD = db.CHITIETHDs.Find(id);
            if (cHITIETHD == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaHD = new SelectList(db.HOADONs, "MaHD", "MaKH", cHITIETHD.MaHD);
            ViewBag.MaQA = new SelectList(db.QUANAOs, "MaQA", "MaLoHang", cHITIETHD.MaQA);
            return View(cHITIETHD);
        }

        // POST: CHITIETHDs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaCTHD,MaHD,MaQA,SoLuong,DonGia")] CHITIETHD cHITIETHD)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cHITIETHD).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaHD = new SelectList(db.HOADONs, "MaHD", "MaKH", cHITIETHD.MaHD);
            ViewBag.MaQA = new SelectList(db.QUANAOs, "MaQA", "MaLoHang", cHITIETHD.MaQA);
            return View(cHITIETHD);
        }

        // GET: CHITIETHDs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CHITIETHD cHITIETHD = db.CHITIETHDs.Find(id);
            if (cHITIETHD == null)
            {
                return HttpNotFound();
            }
            return View(cHITIETHD);
        }

        // POST: CHITIETHDs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            CHITIETHD cHITIETHD = db.CHITIETHDs.Find(id);
            db.CHITIETHDs.Remove(cHITIETHD);
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
