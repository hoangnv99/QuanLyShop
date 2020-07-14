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
    public class NHANVIENsController : Controller
    {
        private de_an_web_ver7Entities db = new de_an_web_ver7Entities();
        public ActionResult TIMKIEM(string maNV = "", string gioitinh = "", string ten = "", string diachi = "", string maPB = "")
        {
            ViewBag.maNV = maNV;
            ViewBag.gioitinh = gioitinh;
            ViewBag.ten = ten;
            ViewBag.diachi = diachi;
            ViewBag.maPB = maPB;
            var nhanViens = db.NHANVIENs.SqlQuery("NHANVIEN2_TimKiem'" + maNV + "','" + gioitinh + "','" + ten + "','" + diachi + "','" + maPB + "'");
            if (nhanViens.Count() == 0)
                ViewBag.TB = "Không có thông tin tìm kiếm.";
            return View(nhanViens.ToList());
        }
        // GET: NHANVIENs
        public ActionResult Index()
        {
            var nHANVIENs = db.NHANVIENs.Include(n => n.PHONGBAN);
            return View(nHANVIENs.ToList());
        }
        public ActionResult View()
        {
            var aa = db.NHANVIENs.Include(n => n.PHONGBAN);
            return View(aa.ToList());
        }
        


        // GET: NHANVIENs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NHANVIEN nHANVIEN = db.NHANVIENs.Find(id);
            if (nHANVIEN == null)
            {
                return HttpNotFound();
            }
            return View(nHANVIEN);
        }

        // GET: NHANVIENs/Create
        public ActionResult Create()
        {
            ViewBag.MaPB = new SelectList(db.PHONGBANs, "MaPB", "TenPB");
            return View();
        }

        // POST: NHANVIENs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public ActionResult Create([Bind(Include = "MaNV,Ho,Ten,NgaySinh,GioiTinh,AnhMinhHoa,Luong,SDT,DiaChi,MaPB")] NHANVIEN nhanVien)
        {
                   
            if (ModelState.IsValid)
            {
                //nhanVien.MaNV = LayMaNV();
             
                db.NHANVIENs.Add(nhanVien);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaPB = new SelectList(db.PHONGBANs, "MaPB", "TenPB", nhanVien.MaPB);
            return View(nhanVien);
        }
        // GET: NHANVIENs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NHANVIEN nHANVIEN = db.NHANVIENs.Find(id);
            if (nHANVIEN == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaPB = new SelectList(db.PHONGBANs, "MaPB", "TenPB", nHANVIEN.MaPB);
            return View(nHANVIEN);
        }

        // POST: NHANVIENs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaNV,Ho,Ten,NgaySinh,GioiTinh,AnhMinhHoa,Luong,SDT,DiaChi,MaPB")] NHANVIEN nHANVIEN)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nHANVIEN).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaPB = new SelectList(db.PHONGBANs, "MaPB", "TenPB", nHANVIEN.MaPB);
            return View(nHANVIEN);
        }

        // GET: NHANVIENs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NHANVIEN nHANVIEN = db.NHANVIENs.Find(id);
            if (nHANVIEN == null)
            {
                return HttpNotFound();
            }
            return View(nHANVIEN);
        }

        // POST: NHANVIENs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            NHANVIEN nHANVIEN = db.NHANVIENs.Find(id);
            db.NHANVIENs.Remove(nHANVIEN);
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
