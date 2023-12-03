using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebQuanLyThuVien.Areas.Admin.Data;
using WebQuanLyThuVien.Models;

namespace WebQuanLyThuVien.Areas.Admin.Interfaces.Services
{
    internal interface INhapSachService
    {
        void Insert(DTO_Tao_Phieu_Nhap obj);
        IEnumerable<CHITIETPN> GetAllChiTietPhieuNhap();
    }
}
