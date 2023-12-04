using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using WebQuanLyThuVien.Areas.Admin.Data;
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
        NhapSachService _nhapSachService = new NhapSachService ();


        // GET: Admin/NhapSach
        public ActionResult Index()
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            else if (Session["chucvu"].ToString().ToLower() == "thuthu")
            {
                return RedirectToAction("loiphanquyen", "phanquyen");
            }
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
            try
            {
                 var sach = _sachService.GetById(id);

                if (sach != null)
                {
                    // Trả về dữ liệu JSON nếu thành công
                    return Json(new { success = true, data = sach });
                }
                else
                {
                    // Trả về thông báo lỗi nếu không tìm thấy sách
                    return Json(new { success = false, message = "Không tìm thấy sách" });
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu có
                Console.WriteLine($"Error in ChiTietSach: {ex.Message}");
                return Json(new { success = false, message = "Đã xảy ra lỗi" });
            }
        }



        
        [HttpPost]
        public ActionResult ThemSach(int maSach, string tenSach, string theLoai, string ngonNgu, string tacGia, string nhaXB, int namXB, int soLuong, decimal giaSach)
        {
            // Lấy danh sách sách đã mượn từ Session hoặc tạo danh sách mới nếu chưa tồn tại
            List<DTO_Sach_Nhap> listSachNhap;

            if (Session["ListSachNhap"] == null)
                listSachNhap = new List<DTO_Sach_Nhap>();
            else
                listSachNhap = (List<DTO_Sach_Nhap>)Session["ListSachNhap"];

            // Tìm xem sách có MaSach trong danh sách chưa
            var existingSach = listSachNhap.FirstOrDefault(s => s.maSach == maSach);

            if (existingSach != null)
            {
                // Nếu đã tồn tại, tăng số lượng, update lại giá sách
                existingSach.soLuong += soLuong;
                existingSach.giaSach = giaSach;
            }
            else
            {
                // Nếu chưa tồn tại, thêm sách mới vào danh sách
                var sachMoi = new DTO_Sach_Nhap
                {
                    maSach = maSach,
                    tenSach = tenSach,
                    theLoai = theLoai,
                    ngonNgu = ngonNgu,
                    tacGia = tacGia,
                    nhaXB = nhaXB,
                    namXB = namXB,
                    soLuong = soLuong,
                    giaSach = giaSach,
                };

                listSachNhap.Add(sachMoi);
            }
            // Lưu danh sách đã cập nhật vào Session
            Session["ListSachNhap"] = listSachNhap;

            // Trả về một JsonResult chứa danh sách sách đã cập nhật
            return Json(listSachNhap);
        }




        [HttpPost]
        public ActionResult LamMoiDanhSachSachNhap()
        {
            Session["ListSachNhap"] = null;
            return Json(new { success = true });
        }



        [HttpPost]
        public ActionResult XoaSachNhap(int maSach)
        {
            // Lấy danh sách sách đã mượn từ Session hoặc tạo danh sách mới nếu chưa tồn tại
            List<DTO_Sach_Nhap> listSachNhap = Session["ListSachNhap"] as List<DTO_Sach_Nhap> ?? new List<DTO_Sach_Nhap>();

            // Tìm và xóa sách khỏi danh sách dựa trên mã sách
            var sachXoa = listSachNhap.FirstOrDefault(s => s.maSach == maSach);
            if (sachXoa != null)
            {
                listSachNhap.Remove(sachXoa);
                Session["ListSachNhap"] = listSachNhap;
                return Json(new { success = true });
            }

            return Json(new { success = false });
        }



        [HttpPost]
        public ActionResult TaoPhieuNhap(int maNhanVien, int maNCC, DateTime ngayNhap)
        {
            DTO_Tao_Phieu_Nhap tpn = new DTO_Tao_Phieu_Nhap();

            tpn.MaNhanVien = maNhanVien;
            tpn.MaNhaCungCap = maNCC;
            tpn.NgayNhap = ngayNhap;
            tpn.listSachNhap= Session["ListSachNhap"] as List<DTO_Sach_Nhap>;

            if (Session["ListSachNhap"] as List<DTO_Sach_Nhap> == null)
                return Json(new { success = false });
            else
            {
                _nhapSachService.Insert(tpn);
                return Json(new { success = true, data = tpn});
            }
        }
    }
}