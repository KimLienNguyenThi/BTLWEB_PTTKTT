﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebQuanLyThuVien.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class QuanLyThuVienEntities : DbContext
    {
        public QuanLyThuVienEntities()
            : base("name=QuanLyThuVienEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ChiTietPM> ChiTietPMs { get; set; }
        public virtual DbSet<CHITIETPN> CHITIETPNs { get; set; }
        public virtual DbSet<ChiTietPT> ChiTietPTs { get; set; }
        public virtual DbSet<ChiTietPTL> ChiTietPTLs { get; set; }
        public virtual DbSet<DocGia> DocGias { get; set; }
        public virtual DbSet<DonViTL> DonViTLs { get; set; }
        public virtual DbSet<KhoSachThanhLy> KhoSachThanhLies { get; set; }
        public virtual DbSet<LOGIN_DG> LOGIN_DG { get; set; }
        public virtual DbSet<LOGIN_NV> LOGIN_NV { get; set; }
        public virtual DbSet<NhaCungCap> NhaCungCaps { get; set; }
        public virtual DbSet<NhanVien> NhanViens { get; set; }
        public virtual DbSet<PhieuMuon> PhieuMuons { get; set; }
        public virtual DbSet<PhieuNhapSach> PhieuNhapSaches { get; set; }
        public virtual DbSet<PhieuThanhLy> PhieuThanhLies { get; set; }
        public virtual DbSet<PhieuTra> PhieuTras { get; set; }
        public virtual DbSet<Sach> Saches { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<TheDocGia> TheDocGias { get; set; }
        public virtual DbSet<TT_SACH> TT_SACH { get; set; }
    }
}
