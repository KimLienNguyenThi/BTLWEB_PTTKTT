//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class ChiTietPTL
    {
        public int MaSach { get; set; }
        public Nullable<int> Soluongtl { get; set; }
        public int MaPTL { get; set; }
    
        public virtual PhieuThanhLy PhieuThanhLy { get; set; }
        public virtual KhoSachThanhLy KhoSachThanhLy { get; set; }
    }
}
