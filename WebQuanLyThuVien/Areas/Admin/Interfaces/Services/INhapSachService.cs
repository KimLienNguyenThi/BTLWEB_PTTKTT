﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebQuanLyThuVien.Areas.Admin.Data;
using WebQuanLyThuVien.Models;

namespace WebQuanLyThuVien.Areas.Admin.Interfaces.Services
{
    public class INhapSachService
    {
        void Insert(DTO_Tao_Phieu_Nhap obj);
        IEnumerable<CHITIETPN> GetAllChiTietPhieuNhap();
    }
}