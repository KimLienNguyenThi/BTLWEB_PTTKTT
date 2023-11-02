using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebQuanLyThuVien.Areas.Admin.Services;

namespace WebQuanLyThuVien.Areas.Admin.Controllers
{
    public class PhieuTraController : Controller
    {
        // GET: Admin/PhieuTra
        DocGiaService _docGiaService = new DocGiaService();
        PhieuMuonService _phieuMuonService = new PhieuMuonService();
        // GET: Admin/PhieuMuon
        public ActionResult Index()
        {
            if (Session["user"] == null)
                return RedirectToAction("Login", "Account");
            else
            {
                var docGia = _docGiaService.GetAllDocGia_TheDocGia();
                ViewData["DocGia"] = docGia;
                var phieuMuon = _phieuMuonService.GetPhieuMuonsDocGia();
                ViewData["PhieuMuon"] = phieuMuon;
                return View();
            }
        }
    }
}