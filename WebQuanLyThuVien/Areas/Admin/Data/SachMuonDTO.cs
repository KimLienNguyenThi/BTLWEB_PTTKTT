using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebQuanLyThuVien.Areas.Admin.Data
{
    public class SachMuonDTO
    {
        public int MaSach { get; set; }
        public string TenSach { get; set; }
        
        public int? SoLuongMuon { get; set; }

    }
}