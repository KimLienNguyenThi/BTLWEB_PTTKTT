using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebQuanLyThuVien.Areas.Admin.Interfaces.Services;
using WebQuanLyThuVien.Areas.Admin.Services;
using WebQuanLyThuVien.Models;
using WebQuanLyThuVien.Services;

namespace WebQuanLyThuVien.Areas.Admin.Controllers
{
    public class NhapSachController : Controller
    {
        SachService _sachService = new SachService();
        NhaCungCapService _nhaCungCapService = new NhaCungCapService();

        // GET: Admin/NhapSach
        public ActionResult Index()
        {
            if (Session["user"] == null)
                return RedirectToAction("Login", "Account");
            else
            {
                var sach = _sachService.GetAll();
                var ncc = _nhaCungCapService.GetAll();

                ViewData["Sach"] = sach;
                ViewData["Ncc"] = ncc;

                return View();
            }
        }

        [HttpPost]
        public ActionResult ThemNhaCungCap(string tenNcc, string sdtNcc, string diaChiNcc)
        {
            try
            {
                NhaCungCap ncc = new NhaCungCap();

                ncc.TenNCC = tenNcc;
                ncc.sdtNCC = sdtNcc;
                ncc.DiaChiNCC = diaChiNcc;

                var success = _nhaCungCapService.Insert(ncc);
                if (success)
                {
                    return Json(new { success = true, message = "Thêm nhà cung cấp thành công." });
                }
                return Json(new { success = false, message = "Thêm nhà cung cấp thất bại." });
            }
            catch (Exception ex)
            {
                // Xử lý các ngoại lệ một cách thích hợp
                return Json(new { success = false, message = "Lỗi xử lý yêu cầu.", error = ex.Message });
            }


        }

        [HttpPost]
        public ActionResult ChiTietSach(int id)
        {
            var sach = _sachService.GetById(id);

            // Trả về dữ liệu JSON
            return Json(new { success = true, data = sach });
        }
    }
}