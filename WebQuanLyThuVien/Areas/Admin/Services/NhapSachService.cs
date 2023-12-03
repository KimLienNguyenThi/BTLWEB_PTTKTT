using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebQuanLyThuVien.Areas.Admin.Data;
using WebQuanLyThuVien.Areas.Admin.Interfaces.Services;
using WebQuanLyThuVien.Interfaces;
using WebQuanLyThuVien.Models;
using WebQuanLyThuVien.Repository;

namespace WebQuanLyThuVien.Areas.Admin.Services
{
    public class NhapSachService : INhapSachService
    {

        private UnitOfWork<QuanLyThuVienEntities> unitOfWork = new UnitOfWork<QuanLyThuVienEntities>();

        public IEnumerable<CHITIETPN> GetAllChiTietPhieuNhap()
        {
            return unitOfWork.Context.CHITIETPNs.ToList();
        }

        public void Insert(DTO_Tao_Phieu_Nhap obj)
        {
            var newPhieuNhap = new PhieuNhapSach
            {
                NgayNhap = obj.NgayNhap,
                MaNV = obj.MaNhanVien,
                MaNCC = obj.MaNhaCungCap,
            };

            unitOfWork.Context.PhieuNhapSaches.Add(newPhieuNhap);
            unitOfWork.Save(); // Lưu thay đổi vào cơ sở dữ liệu

            foreach (var sachNhap in obj.listSachNhap)
            {

                if(sachNhap.maSach > 0)
                {
                    var newChiTietPN = new CHITIETPN
                    {
                        MaPN = newPhieuNhap.MaPN,
                        MaSACH = sachNhap.maSach,
                        GiaSach = sachNhap.giaSach,
                        SoLuongNHAP = sachNhap.soLuong,
                    };

                    unitOfWork.Context.CHITIETPNs.Add(newChiTietPN);
                }
                else
                {
                    var newSach = new Sach
                    {
                        TenSach = sachNhap.tenSach,
                        TheLoai = sachNhap.theLoai,
                        TacGia = sachNhap.tacGia,
                        NgonNgu = sachNhap.ngonNgu,
                        NXB = sachNhap.nhaXB,
                        NamXB = sachNhap.namXB,
                        SoLuongHIENTAI = 0,
                    };

                    unitOfWork.Context.Saches.Add(newSach);
                    unitOfWork.Save(); // Lưu thay đổi vào cơ sở dữ liệu

                    var newChiTietPN = new CHITIETPN
                    {
                        MaPN = newPhieuNhap.MaPN,
                        MaSACH = newSach.MaSach,
                        GiaSach = sachNhap.giaSach,
                        SoLuongNHAP = sachNhap.soLuong,
                    };

                    unitOfWork.Context.CHITIETPNs.Add(newChiTietPN);
                }
            }

            unitOfWork.Save(); // Lưu thay đổi vào cơ sở dữ liệu
        }

    }
}