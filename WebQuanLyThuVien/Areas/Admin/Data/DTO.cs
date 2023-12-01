using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebQuanLyThuVien.Models;

namespace WebQuanLyThuVien.Areas.Admin.Data
{
    public class DTO_DocGia_TheDocGia
    {
            public int MaThe { get; set; }
            public string HoTenDG { get; set; }
            public string SDT { get; set; }
            public string DiaChi { get; set; }
    }


    public class DTO_NhanVien_LoginNV
    {
        public int MaNV { get; set; }
        public string HoTenNV { get; set; }
        public string SDT { get; set; }
        public string DiaChi { get; set; }
        public string ChucVu { get; set; }

        public static explicit operator DTO_NhanVien_LoginNV(NhanVien v)
        {
            return new DTO_NhanVien_LoginNV
            {
                MaNV = v.MaNV,
                HoTenNV = v.HoTenNV,
                SDT = v.SDT,
                DiaChi = v.DiaChi,
                ChucVu = v.ChucVu
            };
        }
    }

    public class DTO_Sach_Muon
    {
        public int MaSach { get; set; }
        public string TenSach { get; set; }
        public int SoLuong { get; set; }
    }

    public class DTO_Tao_Phieu_Muon
    {
        public int MaNhanVien { get; set; }
        public int MaTheDocGia { get; set; }
        public DateTime NgayMuon { get; set; }
        public DateTime NgayTra { get; set; }
        public List<DTO_Sach_Muon> listSachMuon { get; set; }

        public DTO_Tao_Phieu_Muon()
        {
            listSachMuon = new List<DTO_Sach_Muon>();
        }
    }
    public class DTO_Sach_Tra
    {
        public int MaPT { get; set; }
        public int MaSach { get; set; }
        public string TenSach { get; set; }

        public int SoLuongMuon { get; set; }
        public int SoLuongTra { get; set; }
        public int SoLuongLoi { get; set; }
        public decimal PhuThu { get; set; }

    }

    public class DTO_Tao_Phieu_Tra
    {
        public int MaNhanVien { get; set; }
        public int MaTheDocGia { get; set; }
        public DateTime NgayMuon { get; set; }
        public DateTime HanTra { get; set; }
        public DateTime NgayTra { get; set; }

        public List<DTO_Sach_Tra> ListSachTra { get; set; }
        public int MaPhieuMuon { get; set; }

        public decimal PhuThu { get; set; } // Sử dụng decimal cho giá trị tiền tệ
    }


}