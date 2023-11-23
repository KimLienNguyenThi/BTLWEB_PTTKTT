using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebQuanLyThuVien.Areas.Admin.Data;
using WebQuanLyThuVien.Interfaces;
using WebQuanLyThuVien.Interfaces.Services;
using WebQuanLyThuVien.Models;
using WebQuanLyThuVien.Repository;

namespace WebQuanLyThuVien.Services
{


    public class SachService : ISachService
    {

        private ISachRepository _sachRepository;

        private UnitOfWork<QuanLyThuVienEntities> unitOfWork = new UnitOfWork<QuanLyThuVienEntities>();

        public SachService()
        {
            _sachRepository = new SachRepository(unitOfWork);
        }

        public string Delete(int obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Sach> GetAll()
        {
            return _sachRepository.GetAll().ToList();
        }

        public Sach GetById(int id)
        {
            return _sachRepository.GetById(id);
        }
        public IEnumerable<SachDTOcs> GetSACH()
        {
            var listSACH =
                (from SACH in unitOfWork.Context.Saches

                 select new SachDTOcs
                 {
                     MaSach = SACH.MaSach,
                     TenSach = SACH.TenSach,
                     TacGia = SACH.TacGia,
                     /*  TheLoai = SACH.TheLoai,
                       NgonNgu= SACH.NgonNgu,
                       NXB  = SACH.NXB,
                       NamXB = SACH.NamXB,
                       GiaSach = SACH.GiaSach, */
                     SoLuongHIENTAI = SACH.SoLuongHIENTAI
                 }
                 ).ToList();
            return listSACH;

        }

        public void Insert(Sach obj)
        {
        }

        public void Update(Sach obj)
        {
            
        }
    }
}