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

        QuanLyThuVienEntities db = new QuanLyThuVienEntities();

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
                Session["shared_SDT"] = user.SDT;

                TempData["user_name"] = user.SDT;
                TempData["user_password"] = user.PASSWORD_DG;

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

        public ActionResult DangKyTaiKhoan(string hoTen, string email, string sdt, string matKhau)
        {
            mapTaiKhoan map = new mapTaiKhoan();
            LOGIN_DG data = new LOGIN_DG()
            {
                Email = email,
                HoTen = hoTen,
                PASSWORD_DG = matKhau,
                SDT = sdt,
            };

            if (map.ThemMoi(data))
            {
                // Chuyển hướng đến hành động "Index" của controller "User"
                return View();
            }
            else
            {
                // Trả về phản hồi JSON nếu cần
                return Json(new { success = false, message = "Đăng ký thất bại", data = data });
            }
        }


        public ActionResult Logout()
        {
            SessionConfig.SetUser(null);
            return RedirectToAction("Index","Home");
        }

        public ActionResult Profile()
        {
           int maDG = (int)Session["shared_SDT"];
           DocGia dg = db.DocGias.Find(maDG);

           return View(dg);
        }

        public ActionResult UpdatePassWord()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UpdatePassWord(string uname, string pswd, string new_pswd, string new_pswd_check)
        {
            var user_name = TempData["user_name"];
            var user_password = TempData["user_password"];

            if (uname.Equals(user_name) && user_password.Equals(user_password))
            {
                if(new_pswd.Equals(new_pswd_check))
                { 
                    var lg = db.LOGIN_DG.Find(user_name);
                    lg.PASSWORD_DG = new_pswd;
                    db.SaveChanges();
                    return RedirectToAction("Logout");
                }
                else
                {
                    ViewBag.error = "*Thông tin lỗi!";
                    return View();
                }
            }
            else
            {
                ViewBag.error = "*Sai tên đăng nhập!";
                return View();
            }
        }

        
        public ActionResult History()
        {
            
                var sessionValue = Session["shared_SDT"].ToString(); // Convert to string or appropriate type

                var data = db.DkiMuonSaches.Where(m => m.SDT == sessionValue).ToList();

                if (data.Count > 0)
                {
                    return View(data);
                }
                else
                {
                    // Handle when there is no data
                    ViewBag.Message = "Không có dữ liệu.";
                    return View();
                }
            
            
        }

        [HttpPost]
        public ActionResult GetDetails(int maDK)
        {
            
            var details = db.ChiTietDks.Where(d => d.MaDK == maDK).ToList();
            List<ChiTietDk> chiTietDkList = new List<ChiTietDk>();
            foreach (var d in details)
            {
               var chiTietDk = new ChiTietDk()
                {
                    MaDK = d.MaDK,
                    MaSach = d.MaSach,
                    Soluongmuon = d.Soluongmuon
                };
                chiTietDkList.Add(chiTietDk);
            }
            
            return Json(new { success = true, details = chiTietDkList });
        }



    }
}