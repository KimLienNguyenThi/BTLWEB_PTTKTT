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
    public class PhieuMuonCTPhieuMuonService : IPhieuMuonCTPhieuMuonService
    {
        private UnitOfWork<QuanLyThuVienEntities> unitOfWork = new UnitOfWork<QuanLyThuVienEntities>();

        public void Insert(DTO_Tao_Phieu_Muon x)
        {
            var newPhieuMuon = new PhieuMuon
            {
                NgayMuon = x.NgayMuon,
                HanTra = x.NgayTra,
                MaThe = x.MaTheDocGia,
                MaNV = x.MaNhanVien
            };

            unitOfWork.Context.PhieuMuons.Add(newPhieuMuon);
            unitOfWork.Save(); // Lưu thay đổi vào cơ sở dữ liệu

            foreach (var sachMuon in x.listSachMuon)
            {
                var newChiTietPM = new ChiTietPM
                {
                    MaPM = newPhieuMuon.MaPM,
                    MaSach = sachMuon.MaSach,
                    Soluongmuon = sachMuon.SoLuong
                };

                unitOfWork.Context.ChiTietPMs.Add(newChiTietPM);
            }

            unitOfWork.Save(); // Lưu thay đổi vào cơ sở dữ liệu
        }
    }
}