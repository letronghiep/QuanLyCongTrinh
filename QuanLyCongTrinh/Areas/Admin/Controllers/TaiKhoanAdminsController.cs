using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using QuanLyCongTrinh.Helpers;
using QuanLyCongTrinh.Models;

namespace QuanLyCongTrinh.Areas.Admin.Controllers
{
    public class TaiKhoanAdminsController : Controller
    {
        private QuanLyCongTrinhDB db = new QuanLyCongTrinhDB();

        // GET: Admin/TaiKhoans
        public ActionResult Index()
        {
            var taiKhoans = db.TaiKhoans.Include(t => t.Quyen);
            return View(taiKhoans.ToList());
        }

        // GET: Admin/TaiKhoans/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaiKhoan taiKhoan = db.TaiKhoans.Find(id);
            if (taiKhoan == null)
            {
                return HttpNotFound();
            }
            ViewBag.TenQuyen = (from quyen in db.Quyens
                                where quyen.IdQuyen == taiKhoan.IdQuyen
                                select quyen.TenQuyen).FirstOrDefault();
            ViewBag.congtrinhs = (from congtrinh in db.CongTrinhs
                                  where congtrinh.MaTaiKhoan == taiKhoan.MaTaiKhoan
                                  select congtrinh).ToList();
            ViewBag.SoCT = db.CongTrinhs.Count(ct => ct.MaTaiKhoan == taiKhoan.MaTaiKhoan);
            return View(taiKhoan);
        }

        // GET: Admin/TaiKhoans/Create
        public ActionResult Create()
        {
            ViewBag.IdQuyen = new SelectList(db.Quyens, "IdQuyen", "TenQuyen");
            return View();
        }

        // POST: Admin/TaiKhoans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaTaiKhoan,TenTaiKhoan,MatKhau,TenNguoiDung,IdQuyen,ImageUrl, mota")] TaiKhoan taiKhoan)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    taiKhoan.ImageUrl = "";
                    var f = Request.Files["ImageUpload"];
                    if (f != null && f.ContentLength > 0)
                    {
                        string fileName = System.IO.Path.GetFileName(f.FileName);
                        string filePath = Server.MapPath("~/wwwroot/Images/Accounts/" + fileName);
                        f.SaveAs(filePath);
                        taiKhoan.ImageUrl = fileName;
                    }
                    taiKhoan.MatKhau = Helper.GetMD5(taiKhoan.MatKhau);
                    db.TaiKhoans.Add(taiKhoan);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                ViewBag.IdQuyen = new SelectList(db.Quyens, "IdQuyen", "TenQuyen", taiKhoan.IdQuyen);
                ViewBag.err = "Có lỗi xảy ra khi nhập";
                return View(taiKhoan);
            }
        }

        // GET: Admin/TaiKhoans/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaiKhoan taiKhoan = db.TaiKhoans.Find(id);
            if (taiKhoan == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdQuyen = new SelectList(db.Quyens, "IdQuyen", "TenQuyen", taiKhoan.IdQuyen);
            return View(taiKhoan);
        }

        // POST: Admin/TaiKhoans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaTaiKhoan,TenTaiKhoan,MatKhau,TenNguoiDung,IdQuyen,ImageUrl, mota")] TaiKhoan taiKhoan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(taiKhoan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdQuyen = new SelectList(db.Quyens, "IdQuyen", "TenQuyen", taiKhoan.IdQuyen);
            return View(taiKhoan);
        }

        // GET: Admin/TaiKhoans/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaiKhoan taiKhoan = db.TaiKhoans.Find(id);
            if (taiKhoan == null)
            {
                return HttpNotFound();
            }
            return View(taiKhoan);
        }

        // POST: Admin/TaiKhoans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TaiKhoan taiKhoan = db.TaiKhoans.Find(id);
            db.TaiKhoans.Remove(taiKhoan);
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
