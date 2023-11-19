using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebQuanLyThuVien.Areas.Admin.Data;
using WebQuanLyThuVien.Areas.Admin.Interfaces;
using WebQuanLyThuVien.Areas.Admin.Interfaces.Services;
using WebQuanLyThuVien.Areas.Admin.Repository;
using WebQuanLyThuVien.Interfaces;
using WebQuanLyThuVien.Models;
using WebQuanLyThuVien.Repository;

namespace WebQuanLyThuVien.Areas.Admin.Services
{
    public class DocGiaService : IDocGiaService
    {

        private IDocGiaRepository _docGiaRepository;

        private UnitOfWork<QuanLyThuVienEntities> unitOfWork = new UnitOfWork<QuanLyThuVienEntities>();

        public DocGiaService()
        {
            _docGiaRepository = new DocGiaRepository(unitOfWork);
        }

        public string Delete(int obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DocGia> GetAll()
        {
            return _docGiaRepository.GetAll().ToList();

        }

        public IEnumerable<DTO_DocGia_TheDocGia> GetAllDocGia_TheDocGia()
        {
            var listDocGia_TheDocGia =
                (from DocGia in unitOfWork.Context.DocGias
                 join TheDocGia in unitOfWork.Context.TheDocGias
                    on DocGia.MaDG equals TheDocGia.MaDG
                 where TheDocGia.NgayHH >= DateTime.Now
                 select new DTO_DocGia_TheDocGia
                 {
                     MaThe = TheDocGia.MaThe,
                     HoTenDG = DocGia.HoTenDG,
                     SDT = DocGia.SDT,
                     DiaChi = DocGia.DiaChi,
                 }
                 ).ToList();
            return listDocGia_TheDocGia;
        }

        public IEnumerable<DTO_DocGia_TheDocGia> GetAllDocGia_PhieuTra()
        {
            var listDocGia_TheDocGia =
                (from DocGia in unitOfWork.Context.DocGias
                 join TheDocGia in unitOfWork.Context.TheDocGias
                    on DocGia.MaDG equals TheDocGia.MaDG
               //  where TheDocGia.NgayHH >= DateTime.Now
                 select new DTO_DocGia_TheDocGia
                 {
                     MaThe = TheDocGia.MaThe,
                     HoTenDG = DocGia.HoTenDG,
                     SDT = DocGia.SDT,
                     DiaChi = DocGia.DiaChi,
                 }
                 ).ToList();
            return listDocGia_TheDocGia;
        }
        public DocGia GetById(int id)
        {
            throw new NotImplementedException();
        }

        public DocGia GetBySDT(string sdt)
        {
            throw new NotImplementedException();
        }

        public void Insert(DocGia obj)
        {
            throw new NotImplementedException();
        }

        public void Update(DocGia obj)
        {
            throw new NotImplementedException();
        }
    }
}