//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ThuVienBTL.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ChiTietPT
    {
        public Nullable<int> Soluongtra { get; set; }
        public int MaSach { get; set; }
        public int MaPT { get; set; }
    
        public virtual Sach Sach { get; set; }
        public virtual PhieuTra PhieuTra { get; set; }
    }
}
