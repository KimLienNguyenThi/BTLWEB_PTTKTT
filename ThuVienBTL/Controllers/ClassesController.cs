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
            List<Sach> ListSach = db.Saches.ToList();

            return View(ListSach);
        }

        public ActionResult DanhSachSach() 
        {
            // Lấy danh sách dữ liệu trong bảng
            List<Sach> ListSach = db.Saches.ToList();

            return View(ListSach);
        }

        [HttpPost]
        public ActionResult SearchSach(string search)
        {
            if (string.IsNullOrEmpty(search))
            {
                return View("Index");
            }
            else
            {
                try
                {
                    List<Sach> sachLoc = db.Saches.Where(item => item.TenSach.Contains(search)
                    || item.TheLoai.Contains(search) || item.TacGia.Contains(search) || item.NgonNgu.Contains(search)
                    || item.NXB.Contains(search)).ToList();

                    return View(sachLoc);
                    //return Json(sachLoc);
                }
                catch
                {
                    return View("Index");
                }
            }
        }
    }
}