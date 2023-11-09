using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using ThuVienBTL.Models;

namespace ThuVienBTL.Controllers
{
    public class AboutController : Controller
    {
        QuanLyThuVienEntities db = new QuanLyThuVienEntities();

        // GET: About

        public ActionResult Index()
        {
            return View();
        }

        //public ActionResult Index()
        //{
        //    // Lấy danh sách dữ liệu trong bảng
        //    List<Sach> ListSach = db.Saches.ToList();

        //    return View(ListSach);
        //}

        //public ActionResult ThemSachMoi() 
        //{
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult ThemSachMoi(Sach model) 
        //{
        //    // Thêm mới bản ghi
        //    db.Saches.Add(model);

        //    // Lưu lại thay đổi
        //    db.SaveChanges();

        //    return RedirectToAction("Index");
        //}

        //public ActionResult SuaThongTinSach(int maSach)
        //{
        //    // Tìm sách cần sửa theo mã sách
        //    Sach sach = db.Saches.Find(maSach);

        //    return View(sach);
        //}

        //[HttpPost]
        //public ActionResult SuaThongTinSach(Sach model)
        //{

        //    // Tìm sách cần sửa theo mã sách
        //    Sach sach = db.Saches.Find(model.MaSach);

        //    // Sửa thông tin sách
        //    sach.MaSach = model.MaSach;
        //    sach.GiaSach = model.GiaSach;
        //    sach.TacGia = model.TacGia;
        //    sach.TenSach = model.TenSach;
        //    sach.TheLoai = model.TheLoai;
        //    sach.NgonNgu = model.NgonNgu;
        //    sach.NamXB = model.NamXB;
        //    sach.NXB = model.NXB;
        //    sach.SoLuongHIENTAI = model.SoLuongHIENTAI;

        //    // Lưu thay đổi
        //    db.SaveChanges();

        //    return RedirectToAction("Index");
        //}

        //public ActionResult XoaThongTinSach(int maSach)
        //{
        //    // Tìm sách cần xoá theo mã sách
        //    Sach sach = db.Saches.Find(maSach);
        //    db.Saches.Remove(sach);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

    }
}