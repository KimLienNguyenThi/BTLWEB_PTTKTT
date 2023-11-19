using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
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
                    // HoTenNV = NhanVien.HoTenNV,
                     MaThe = DocGia.MaDG,
                     HoTenDG = DocGia.HoTenDG,
                     SDT = DocGia.SDT
                 }
                 ).ToList();
            return listPhieuMuon_DocGia;
        }


      
        public IEnumerable<PhieuMuon_DTO> GetPhieuMuonsChuaTraSach()
        {
            var distinctPhieuMuonNotInPhieuTra =
                (from PhieuMuon in unitOfWork.Context.PhieuMuons
                 join DocGia in unitOfWork.Context.DocGias
                    on PhieuMuon.MaThe equals DocGia.MaDG
                 join CHITIETPM in unitOfWork.Context.ChiTietPMs
                 on PhieuMuon.MaPM equals CHITIETPM.MaPM
                 where !(
                         from CHITIETPT in unitOfWork.Context.ChiTietPTs
                         join PHIEUTRA in unitOfWork.Context.PhieuTras
                            on CHITIETPT.MaPT equals PHIEUTRA.MaPT
                         join DocGia in unitOfWork.Context.DocGias
                          on PHIEUTRA.MaThe equals DocGia.MaDG
                         where PhieuMuon.MaThe == PHIEUTRA.MaThe
                          && CHITIETPM.Soluongmuon == CHITIETPT.Soluongtra+ CHITIETPT.Soluongloi
                          && CHITIETPM.MaSach == CHITIETPT.MaSach
                         select 1
                      ).Any()
                 select new PhieuMuon_DTO
                 {
                     MaPM = PhieuMuon.MaPM,
                     MaThe = DocGia.MaDG,
                     HoTenDG = DocGia.HoTenDG,
                     SDT = DocGia.SDT,
                     NgayMuon = PhieuMuon.NgayMuon,
                     HanTra = PhieuMuon.HanTra
                 }
                ).Distinct().ToList();

            return distinctPhieuMuonNotInPhieuTra;
        }

        public IEnumerable<PhieuMuon_DTO> SearchPhieuMuon(string searchTerm)
        {
           
            var distinctPhieuMuonNotInPhieuTra =
                (from PhieuMuon in unitOfWork.Context.PhieuMuons
                 join DocGia in unitOfWork.Context.DocGias
                    on PhieuMuon.MaThe equals DocGia.MaDG
                 join CHITIETPM in unitOfWork.Context.ChiTietPMs
                 on PhieuMuon.MaPM equals CHITIETPM.MaPM
                 where !(
                         from CHITIETPT in unitOfWork.Context.ChiTietPTs
                         join PHIEUTRA in unitOfWork.Context.PhieuTras
                            on CHITIETPT.MaPT equals PHIEUTRA.MaPT
                         join DocGia in unitOfWork.Context.DocGias
                          on PHIEUTRA.MaThe equals DocGia.MaDG
                         where PhieuMuon.MaThe == PHIEUTRA.MaThe
                          && CHITIETPM.Soluongmuon == CHITIETPT.Soluongtra
                          && CHITIETPM.MaSach == CHITIETPT.MaSach
                         select 1
                      ).Any()  && (DocGia.HoTenDG.Contains(searchTerm)
            || DocGia.SDT.Contains(searchTerm))
                 select new PhieuMuon_DTO
                 {
                     MaPM = PhieuMuon.MaPM,
                     MaThe = DocGia.MaDG,
                     HoTenDG = DocGia.HoTenDG,
                     SDT = DocGia.SDT,
                     NgayMuon = PhieuMuon.NgayMuon,
                     HanTra = PhieuMuon.HanTra
                 }
                ).Distinct().ToList();

            return distinctPhieuMuonNotInPhieuTra;
        }


        public IEnumerable<SachMuonDTO> getSachMuon(int MaPm)
        {
            var SoLuongSachMuon =
                (from PhieuMuon in unitOfWork.Context.PhieuMuons
                 join CHITIETPM in unitOfWork.Context.ChiTietPMs
                 on PhieuMuon.MaPM equals CHITIETPM.MaPM
                 join Sach in unitOfWork.Context.Saches
                    on CHITIETPM.MaSach equals Sach.MaSach
                 where !(
                         from CHITIETPT in unitOfWork.Context.ChiTietPTs
                         join PHIEUTRA in unitOfWork.Context.PhieuTras
                            on CHITIETPT.MaPT equals PHIEUTRA.MaPT
                         join Sach in unitOfWork.Context.Saches
                on CHITIETPT.MaSach equals Sach.MaSach
                         where PhieuMuon.MaThe == PHIEUTRA.MaThe
                          && CHITIETPM.MaSach == CHITIETPT.MaSach
                        /*   PhieuMuon.MaPM == PHIEUTRA.MaPM*/
                         select 1
                      ).Any() && PhieuMuon.MaPM == MaPm
                 select new SachMuonDTO
                 {
                     MaSach = CHITIETPM.MaSach, 
                     TenSach = Sach.TenSach,
                     SoLuongMuon = CHITIETPM.Soluongmuon

                 }
                ).ToList();

            return SoLuongSachMuon;
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