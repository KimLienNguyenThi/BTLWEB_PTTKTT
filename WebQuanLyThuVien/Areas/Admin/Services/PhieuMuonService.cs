using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebQuanLyThuVien.Areas.Admin.Data;
using WebQuanLyThuVien.Areas.Admin.Interfaces;
using WebQuanLyThuVien.Areas.Admin.Interfaces.Services;
using WebQuanLyThuVien.Areas.Admin.Repository;
using WebQuanLyThuVien.Models;
using WebQuanLyThuVien.Repository;

namespace WebQuanLyThuVien.Areas.Admin.Services
{
    public class PhieuMuonService : IPhieuMuonService
    {
        private IDocGiaRepository _docGiaRepository;

        private UnitOfWork<QuanLyThuVienEntities> unitOfWork = new UnitOfWork<QuanLyThuVienEntities>();

        public PhieuMuonService()
        {
            //_docGiaRepository = new DocGiaRepository(unitOfWork);


        }

        public string Delete(int obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PhieuMuon> GetAll()
        {
            throw new NotImplementedException();
        }

        public PhieuMuon GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PhieuMuon_DTO> GetPhieuMuonsDocGia()
        {
            var listPhieuMuon_DocGia =
                (from PhieuMuon in unitOfWork.Context.PhieuMuons
                 join DocGia in unitOfWork.Context.DocGias
                    on PhieuMuon.MaThe equals DocGia.MaDG
                 join NhanVien in unitOfWork.Context.NhanViens
                 on PhieuMuon.MaNV equals NhanVien.MaNV
                 // where TheDocGia.NgayHH >= DateTime.Now
                 select new PhieuMuon_DTO
                 {
                     MaPM = PhieuMuon.MaPM,
                     NgayMuon = PhieuMuon.NgayMuon,
                     HanTra = PhieuMuon.HanTra,
                     MaNV = NhanVien.MaNV,
                     HoTenNV = NhanVien.HoTenNV,
                     MaThe = DocGia.MaDG,
                     HoTenDG = DocGia.HoTenDG

                 }
                 ).ToList();
            return listPhieuMuon_DocGia;
        }

        public void Insert(PhieuMuon obj)
        {
            throw new NotImplementedException();
        }

        public void Update(PhieuMuon obj)
        {
            throw new NotImplementedException();
        }
    }
}