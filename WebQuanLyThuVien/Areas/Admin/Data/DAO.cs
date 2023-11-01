//using System;
//using System.Collections.Generic;
//using System.Data.SqlClient;
//using System.Linq;
//using System.Web;
//using WebQuanLyThuVien.Models;


//namespace WebQuanLyThuVien.Areas.Admin.Data
//{
//    public class DAO
//    {
//        private static DAO instance;

//        internal static DAO Instance
//        {
//            get
//            {
//                if (instance == null)
//                    instance = new DAO();
//                return instance;
//            }
//        }

//        //------------------------Phiếu mượn----------------------------

//        // Lấy danh sách ThongTinDocGia thông qua TheDocGia và DocGia
//        public List<DTO_TTinDocGia_PM> GetThongTinDocGia_PM()
//        {
//            List<DTO_TTinDocGia_PM> listThongTinDocGia = new List<DTO_TTinDocGia_PM>();

//            using (QuanLyThuVienEntities db = new QuanLyThuVienEntities())
//            {
//                string sql = "select t.MaThe, d.HoTenDG, d.SDT, d.DiaChi from DocGia d join TheDocGia t on t.madg = d.madg where t.MaDG = d.MaDG";

//                listThongTinDocGia = db.Database.SqlQuery<DTO_TTinDocGia_PM>(sql).ToList();
//            }

//            return listThongTinDocGia;
//        }

//        //
//    }
//}