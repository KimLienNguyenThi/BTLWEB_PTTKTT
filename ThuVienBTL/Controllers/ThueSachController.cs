using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using ThuVienBTL.App_Start;
using ThuVienBTL.Models;

namespace ThuVienBTL.Controllers
{
    public class ThueSachController : Controller
    {
        // GET: ThueSach
        QuanLyThuVienEntities db = new QuanLyThuVienEntities();

        public ActionResult Index()
        {
            // Kiem tra quyen su dung
            //var user = SessionConfig.GetUser();
            //if (user == null)
            //{
            //    return RedirectToAction("Index", "User");
            //}

            List<Sach> ListSach = db.Saches.ToList();

            return View(ListSach);
        }

        [HttpPost]
        public ActionResult LocYeuCau(string NgonNgu, string TheLoai, string NamXB)
        {
            List<Sach> sachLocNgonNgu;
            List<Sach> sachLocTheLoai;
            List<Sach> sachLocNamXB;

            // Lọc theo ngôn ngữ
            if (NgonNgu.ToString() != "All")
            {
                // nếu có chọn lọc ngôn ngữ thì tiến hành lọc
                sachLocNgonNgu = db.Saches.Where(m => m.NgonNgu == NgonNgu).ToList();
            }
            else
            {
                sachLocNgonNgu = db.Saches.ToList();
            }

            // Lọc theo thể loại
            if (TheLoai.ToString() != "All")
            {
                sachLocTheLoai = sachLocNgonNgu.Where(m=>m.TheLoai == TheLoai).ToList();
            }
            else
            {
                sachLocTheLoai = sachLocNgonNgu;
            }

            // Lọc theo năm xuất bản
            if (NamXB.ToString() != "All")
            {
                int number = int.Parse(NamXB);
                sachLocNamXB = sachLocTheLoai.Where(m =>m.NamXB == number).ToList();
            }
            else
            {
                sachLocNamXB = sachLocTheLoai;
            }

            return View(sachLocNamXB);
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

        public void DangKyMuon(object sender, CommandEventArgs e)
        {
            string maSachMuon = e.CommandArgument.ToString();

        }

    }
}