using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebQuanLyThuVien.Areas.Admin.Data;
using WebQuanLyThuVien.Models;

namespace WebQuanLyThuVien.Areas.Admin.Interfaces.Services
{
    internal interface IDocGiaService
    {

        IEnumerable<DocGia> GetAll();
        DocGia GetById(int id);
        void Insert(DocGia obj);
        void Update(DocGia obj);
        string Delete(int obj);

        // ví dụ 1 phương thức đặc thù
        DocGia GetBySDT(string sdt);
        IEnumerable<DTO_DocGia_TheDocGia> GetAllDocGia_TheDocGia();

    }
}
