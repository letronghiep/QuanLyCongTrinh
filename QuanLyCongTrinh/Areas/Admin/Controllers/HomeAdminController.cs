using QuanLyCongTrinh.Helpers;
using QuanLyCongTrinh.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace QuanLyCongTrinh.Areas.Admin.Controllers
{
    public class HomeAdminController : Controller
    {
        QuanLyCongTrinhDB db = new QuanLyCongTrinhDB();



        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string TenTaiKhoan, string MatKhau)
        {
            string password = Helper.GetMD5(MatKhau);
            var userCheck = db.TaiKhoans.FirstOrDefault(acc => acc.TenTaiKhoan.Equals(TenTaiKhoan) && acc.MatKhau.Equals(password));
            if (userCheck != null && userCheck.IdQuyen == 1)
            {
                Session["user"] = userCheck;
                return RedirectToAction("Index", "HomeAdmin");

            }
            else
            {
                ViewBag.errLogin = "Tên đăng nhập hoặc mật khẩu sai";
                return View("Login");
            }
        }
        public ActionResult Logout()
        {
            Session.Remove("user");
            return RedirectToAction("Index");
        }
        // GET: Admin/Home
        public ActionResult Index()
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("Login");
            }
            else
                return View();
        }
        public ActionResult About()
        {
            return View();
        }
    }
}