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
    
    public partial class ChiTietPM
    {
        public int MaPM { get; set; }
        public int MaSach { get; set; }
        public Nullable<int> Soluongmuon { get; set; }
    
        public virtual Sach Sach { get; set; }
        public virtual PhieuMuon PhieuMuon { get; set; }
    }
}
