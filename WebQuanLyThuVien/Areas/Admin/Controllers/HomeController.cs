using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebQuanLyThuVien.Models;
using WebQuanLyThuVien.Services;

namespace WebQuanLyThuVien.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        NhanVienService _nhanVienService = new NhanVienService();

        // GET: Admin/Home
        public ActionResult Index()
        {
            var items = _nhanVienService.GetAll();
            return View(items);
        }
    }
}