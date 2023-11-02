using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebQuanLyThuVien.Areas.Admin.Controllers
{
    public class PhieuTraController : Controller
    {
        // GET: Admin/PhieuTra
        public ActionResult Index()
        {
            if (Session["user"] == null)
                return RedirectToAction("Login", "Account");
            else
            {
                return View();
            }
        }
    }
}