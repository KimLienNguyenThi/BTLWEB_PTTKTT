﻿using System.Collections.Generic;
using WebQuanLyThuVien.Models;

namespace WebQuanLyThuVien.Interfaces
{
    public interface INhanVienRepository
    {
        IEnumerable<NhanVien> GetAll();
        NhanVien GetById(int id);
        int Insert(NhanVien obj);
        int Update(NhanVien obj);
        int Delete(int obj);

        NhanVien GetBySDT(string sdt);
    }
}

