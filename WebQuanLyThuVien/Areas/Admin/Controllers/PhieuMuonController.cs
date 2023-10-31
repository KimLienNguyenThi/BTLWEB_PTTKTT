using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebQuanLyThuVien.Models;

namespace WebQuanLyThuVien.Areas.Admin.Controllers
{
    public class PhieuMuonController : Controller
    {
        QuanLyThuVienEntities db = new QuanLyThuVienEntities();

        // GET: Admin/PhieuMuon
        public ActionResult Index()
        {
            var items = db.DocGias.ToList();
            return View(items);
        }
    }
}