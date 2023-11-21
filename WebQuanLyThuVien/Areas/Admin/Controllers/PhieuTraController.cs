using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebQuanLyThuVien.Areas.Admin.Data;
using WebQuanLyThuVien.Areas.Admin.Interfaces.Services;
using WebQuanLyThuVien.Areas.Admin.Services;
using WebQuanLyThuVien.Models;
using WebQuanLyThuVien.Services;
using System.Transactions;

namespace WebQuanLyThuVien.Areas.Admin.Controllers
{

    public class PhieuTraController : Controller
    {
        // GET: Admin/PhieuTra
        DocGiaService _docGiaService = new DocGiaService();
        PhieuMuonService _phieuMuonService = new PhieuMuonService();

        PhieuMuonService _sachMuonService = new PhieuMuonService();
        PhieuTraCTPhieuTraService _phieuTraCTPhieuTraService =  new PhieuTraCTPhieuTraService();
        // GET: Admin/PhieuMuon
        public ActionResult Index()
        {
            if (Session["user"] == null)
                return RedirectToAction("Login", "Account");
            else
            {
             /*   var docGia = _docGiaService.GetAllDocGia_PhieuTra();
                ViewData["DocGia"] = docGia;*/
                var phieuMuon = _phieuMuonService.GetPhieuMuonsChuaTraSach();
                ViewData["PhieuMuon"] = phieuMuon;
                //   ViewData["SachMuon"] = new List<WebQuanLyThuVien.Areas.Admin.Data.SachMuonDTO>();
                return View();
            }
        }

        public ActionResult Search(string keyword)
        {
            if (Session["user"] == null)
                return RedirectToAction("Login", "Account");
            else
            {
             /*   var docGia = _docGiaService.GetAllDocGia_PhieuTra();
                ViewData["DocGia"] = docGia;*/

                IEnumerable<PhieuMuon_DTO> phieuMuon;
                if (!string.IsNullOrEmpty(keyword))
                {
                    // Sử dụng hàm SearchPhieuMuon từ service để tìm kiếm
                    phieuMuon = _phieuMuonService.SearchPhieuMuon(keyword);
                }
                else
                {
                    // Nếu không có từ khóa, hiển thị tất cả phiếu mượn
                    phieuMuon = _phieuMuonService.GetPhieuMuonsChuaTraSach();
                }

                ViewData["PhieuMuon"] = phieuMuon;
                //  ViewData["SachMuon"] = new List<WebQuanLyThuVien.Areas.Admin.Data.SachMuonDTO>();
                return View("Index");
            }
        }


        /// <summary>
        ///  Hàm này dùng cho ajax gọi
        /// </summary>
        /// <param name="maPM"></param>
        /// <returns></returns>

        [HttpGet]
        public JsonResult GetSachMuon(int maPM)
        {
            if (maPM != 0)
            {
                // Nếu phieumuon tồn tại, tiếp tục thực hiện các thao tác khác
                var sachMuon = _sachMuonService.getSachMuon(maPM); // Thay thế bằng phương thức thực tế để lấy dữ liệu sách mượn
                return Json(new ApiOkResponse(sachMuon.ToList()), JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new ApiNotFoundResponse(""), JsonRequestBehavior.AllowGet);
            }
        }
       
   
        
        
            [HttpPost]
            public ActionResult TaoPhieuTra(DTO_Tao_Phieu_Tra data)
            {

                try
                {
                    var success = _phieuTraCTPhieuTraService.Insert(data);
                if (success)
                {  // Trả về phản hồi thành công
                   // var phieuMuon = _phieuMuonService.GetPhieuMuonsChuaTraSach();
                    return Json(new { success = true, message = "Tạo phiếu trả thành công." });
                   
                }
                return Json(new { success = false, message = "Tạo phiếu trả thất bại." });

            }
            
            
                catch (Exception ex)
                {
                    // Xử lý các ngoại lệ một cách thích hợp
                    return Json(new { success = false, message = "Lỗi xử lý yêu cầu.", error = ex.Message });
                }



            }

        }




    }

