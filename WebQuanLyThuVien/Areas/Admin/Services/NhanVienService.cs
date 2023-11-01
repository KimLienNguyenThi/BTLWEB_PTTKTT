using System;
using System.Collections.Generic;
using WebQuanLyThuVien.Interfaces;
using WebQuanLyThuVien.Interfaces.Services;
using WebQuanLyThuVien.Models;
using WebQuanLyThuVien.Repository;

namespace WebQuanLyThuVien.Services
{
    /// <summary>
    /// Service dùng để sử lý logic, kiểm tra đầu vào.....
    /// 
    /// VD: Thêm 1 nhân viên, giao diện người dùng truyền data sáng controller => kiểm tra thông tin đúng hết mới gọi repo
    /// </summary>
    public class NhanVienService : INhanVienService
    {
        private INhanVienRepository _nhanVienRepository;

        private UnitOfWork<QuanLyThuVienEntities> unitOfWork = new UnitOfWork<QuanLyThuVienEntities>();

        public NhanVienService()
        {
            _nhanVienRepository = new NhanVienRepository(unitOfWork);
        }


        /// <summary>
        /// KHi xoá chú ý có thể xảy ra lỗi liên quan khoá ngoại nằm ở bảng khác
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string Delete(int id)
        {
            // check xem nếu thành công hình như sẽ > 0 trả return thông báo cho UI người dùng
            var isSuccess = _nhanVienRepository.Delete(id);
            if (isSuccess > 0)
                return "Xoá thành công";

            return "Xoá không thành công";
        }

        public IEnumerable<NhanVien> GetAll()
        {
            return _nhanVienRepository.GetAll();
        }

        public NhanVien GetById(int id)
        {
            var data = _nhanVienRepository.GetById(id);
            // check null gì đó ....
            return data;
        }

        public NhanVien GetBySDT(string sdt)
        {
            var data = _nhanVienRepository.GetBySDT(sdt);
            // check null gì đó ....
            return data;
        }

        public void Insert(NhanVien obj)
        {
            // nên kiểm tra đầu vào trước khi gọi......


            // check xem nếu thành công hình như sẽ > 0 trả return thông báo cho UI người dùng
            var isSuccess = _nhanVienRepository.Insert(obj);
        }

        public void Update(NhanVien nhanvien)
        { 
            // check xem nếu thành công hình như sẽ > 0 trả return thông báo cho UI người dùng
            var isSuccess =  _nhanVienRepository.Update(nhanvien);
        }
    }
}
