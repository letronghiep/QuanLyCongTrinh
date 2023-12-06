using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QuanLyCongTrinh.Models;

namespace QuanLyCongTrinh.Areas.Admin.Controllers
{
    public class CongTrinhAdminsController : Controller
    {
        private QuanLyCongTrinhDB db = new QuanLyCongTrinhDB();

        // GET: Admin/CongTrinhAdmins
        public ActionResult Index()
        {
            var congTrinhs = db.CongTrinhs.Include(c => c.TaiKhoan);
            return View(congTrinhs.ToList());
        }

        // GET: Admin/CongTrinhAdmins/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CongTrinh congTrinh = db.CongTrinhs.Find(id);
            if (congTrinh == null)
            {
                return HttpNotFound();
            }
            return View(congTrinh);
        }

        // GET: Admin/CongTrinhAdmins/Create
        public ActionResult Create()
        {
            ViewBag.MaTaiKhoan = new SelectList(db.TaiKhoans, "MaTaiKhoan", "TenTaiKhoan");
            return View();
        }

        // POST: Admin/CongTrinhAdmins/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaCT,TenCT,MaTaiKhoan,NgayBatDau,NgayKetThuc,ChuThau,ThoChinh,ThoPhu,SoDu")] CongTrinh congTrinh)
        {
            if (ModelState.IsValid)
            {
                db.CongTrinhs.Add(congTrinh);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaTaiKhoan = new SelectList(db.TaiKhoans, "MaTaiKhoan", "TenTaiKhoan", congTrinh.MaTaiKhoan);
            return View(congTrinh);
        }

        // GET: Admin/CongTrinhAdmins/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CongTrinh congTrinh = db.CongTrinhs.Find(id);
            if (congTrinh == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaTaiKhoan = new SelectList(db.TaiKhoans, "MaTaiKhoan", "TenTaiKhoan", congTrinh.MaTaiKhoan);
            return View(congTrinh);
        }

        // POST: Admin/CongTrinhAdmins/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaCT,TenCT,MaTaiKhoan,NgayBatDau,NgayKetThuc,ChuThau,ThoChinh,ThoPhu,SoDu")] CongTrinh congTrinh)
        {
            if (ModelState.IsValid)
            {
                db.Entry(congTrinh).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaTaiKhoan = new SelectList(db.TaiKhoans, "MaTaiKhoan", "TenTaiKhoan", congTrinh.MaTaiKhoan);
            return View(congTrinh);
        }

        // GET: Admin/CongTrinhAdmins/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CongTrinh congTrinh = db.CongTrinhs.Find(id);
            if (congTrinh == null)
            {
                return HttpNotFound();
            }
            return View(congTrinh);
        }

        // POST: Admin/CongTrinhAdmins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CongTrinh congTrinh = db.CongTrinhs.Find(id);
            db.CongTrinhs.Remove(congTrinh);
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
