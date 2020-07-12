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
    public class QUANTRIsController : Controller
    {
        private de_an_web_ver7Entities db = new de_an_web_ver7Entities();

        // GET: QUANTRIs
        public ActionResult Index()
        {
            return View(db.QUANTRIs.ToList());
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
