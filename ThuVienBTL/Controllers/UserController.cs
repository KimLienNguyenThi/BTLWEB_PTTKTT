using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;
using ThuVienBTL.App_Start;
using ThuVienBTL.Models;

namespace ThuVienBTL.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string uname, string pswd)
        {
            mapTaiKhoan map = new mapTaiKhoan();
            var user = map.TimKiem(uname, pswd);

            // 1. Co thi sang trang chu
            if(user != null)
            {
                SessionConfig.SetUser(user);
                Session["sharedData"] = user.MaDG;

                return RedirectToAction("Index", "Home");
            }
                // 2. Khong co, quay lai trang login, bao loi
                ViewBag.error = "* Tên đăng nhập hoặc mật khẩu sai";
                return View();
        }

        public ActionResult DangKy() 
        {
            return View();
        }

        [HttpPost]
        public ActionResult DangKy(LOGIN_DG model)
        {
            mapTaiKhoan map = new mapTaiKhoan();

            if(model.PASSWORD_DG.IsEmpty() || model.HoTen_DG.IsEmpty() || model.USERNAME_DG.IsEmpty())
            {
                ViewBag.errorInfo = "* Thông tin không được để trống";
                return View(model);
            }
            else
            {
                if (map.ThemMoi(model) == true)
                {
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    ViewBag.error = "* Thông tin không hợp lệ hoặc đã bị trùng";
                    return View(model);
                }
            }
        }

        public ActionResult Logout()
        {
            SessionConfig.SetUser(null);
            return RedirectToAction("Index","Home");
        }

        public ActionResult Profile()
        {
           QuanLyThuVienEntities db = new QuanLyThuVienEntities();

           int maDG = (int)Session["sharedData"];
           DocGia dg = db.DocGias.Find(maDG);

           return View(dg);
        }

        [HttpPost]
        public ActionResult Profile(int madg)
        {


            return View();
        }
    }
}