using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebQuanLyThuVien.Areas.Admin.Data;
using WebQuanLyThuVien.Areas.Admin.Services;
using WebQuanLyThuVien.Interfaces.Services;
using WebQuanLyThuVien.Models;
using WebQuanLyThuVien.Services;

namespace WebQuanLyThuVien.Areas.Admin.Controllers
{
    public class PhieuMuonController : Controller
    {
        SachService _sachService = new SachService();
        DocGiaService _docGiaService = new DocGiaService();
        // GET: Admin/PhieuMuon
        public ActionResult Index()
        {
            if (Session["user"] == null)
                return RedirectToAction("Login", "Account");
            else
            {
                var sach = _sachService.GetAll();
                var docGia = _docGiaService.GetAllDocGia_TheDocGia();

                ViewData["Sach"] = sach;
                ViewData["DocGia"] = docGia;

                return View();
            }
        }
    }
}