using Microsoft.Ajax.Utilities;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Mvc;
using ThuVienBTL.App_Start;
using ThuVienBTL.Models;

namespace ThuVienBTL.Controllers
{
    public class ClassesController : Controller
    {
        QuanLyThuVienEntities db = new QuanLyThuVienEntities();

        // GET: Classess    
        public ActionResult Index()
        {
            // Kiem tra quyen su dung
            var user = SessionConfig.GetUser();
            if(user == null)
            {
                return RedirectToAction("Index", "User");
            }

            List<Sach> ListSach = db.Saches.ToList();

            return View(ListSach);
        }

        public ActionResult DanhSachSach() 
        {
            // Lấy danh sách dữ liệu trong bảng
            List<Sach> ListSach = db.Saches.ToList();

            return View(ListSach);
        }

    }
}