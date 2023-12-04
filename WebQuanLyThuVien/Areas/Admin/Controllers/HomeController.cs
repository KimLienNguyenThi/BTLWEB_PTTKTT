using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebQuanLyThuVien.Areas.Admin.Services;
using WebQuanLyThuVien.Models;
using WebQuanLyThuVien.Services;

namespace WebQuanLyThuVien.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        DocGiaService docGiaService = new DocGiaService();
        SachService sachService = new SachService();
        NhapSachService nhapSachService = new NhapSachService();

        // GET: Admin/Home
        public ActionResult Index()
        {
            if (Session["user"] == null)
                return RedirectToAction("Login", "Account");
            else
            {
                var theDocGia = docGiaService.GetAllTheDocGia();
                var sach = sachService.GetAll();
                var chiTietPN = nhapSachService.GetAllChiTietPhieuNhap();

                decimal tongTienDangKyThe = 0;
                var soLuongDocGia = 0;
                var soLuongSach = 0;
                decimal tongTienNhapSach = 0;

                foreach (var item in theDocGia)
                {
                    tongTienDangKyThe = tongTienDangKyThe + item.TienThe;
                    soLuongDocGia += 1;
                }

                foreach (var item in sach)
                {
                    soLuongSach += item.SoLuongHIENTAI.Value;
                }

                foreach (var item in chiTietPN)
                {
                    tongTienNhapSach += (int)item.GiaSach.Value * (int)item.SoLuongNHAP.Value;
                }

                ViewData["tongTienDangKyThe"] = tongTienDangKyThe;
                ViewData["soLuongDocGia"] = soLuongDocGia;
                ViewData["soLuongSach"] = soLuongSach;
                ViewData["tongTienNhapSach"] = tongTienNhapSach;

                return View();
            }
        }
    }
}