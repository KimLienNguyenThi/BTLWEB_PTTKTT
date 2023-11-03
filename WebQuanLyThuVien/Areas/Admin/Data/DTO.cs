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

}