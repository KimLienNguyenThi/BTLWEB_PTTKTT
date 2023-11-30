using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebQuanLyThuVien.Areas.Admin.Data;
using WebQuanLyThuVien.Areas.Admin.Interfaces;
using WebQuanLyThuVien.Areas.Admin.Interfaces.Services;
using WebQuanLyThuVien.Models;
using WebQuanLyThuVien.Repository;

namespace WebQuanLyThuVien.Areas.Admin.Services
{
    public class NhaCungCapService : INhaCungCapService
    {
        //private IDocGiaRepository _docGiaRepository;

        private UnitOfWork<QuanLyThuVienEntities> unitOfWork = new UnitOfWork<QuanLyThuVienEntities>();

        public NhaCungCapService()
        {
        }


        public string Delete(int obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<NhaCungCap> GetAll()
        {
            return unitOfWork.Context.NhaCungCaps.ToList();
        }

        public NhaCungCap GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(NhaCungCap obj)
        {
            unitOfWork.Context.NhaCungCaps.Add(obj);

            if (obj.TenNCC == "" || obj.sdtNCC == "" || obj.DiaChiNCC == "")
            {
                return false;
            }
            try
            {
                unitOfWork.CreateTransaction(); // Bắt đầu giao dịch

                // Lưu thay đổi vào cơ sở dữ liệu khi mọi thứ đã thành công
                unitOfWork.Commit();

                unitOfWork.Save();

                return true;
            }

            catch (Exception ex)
            {
                unitOfWork.Rollback(); // Rollback nếu có lỗi
                Console.WriteLine($"Error: {ex.Message}");
                // Xử lý lỗi và ghi log
                return false;
            }
            finally
            {
                unitOfWork.Dispose(); // Giải phóng tài nguyên
            }

        }

        public void Update(NhaCungCap obj)
        {
            throw new NotImplementedException();
        }
    }
}