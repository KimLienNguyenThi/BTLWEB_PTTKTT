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
    
    public partial class LOGIN_NV
    {
        public string USERNAME_NV { get; set; }
        public string PASSWORD_NV { get; set; }
        public Nullable<int> MANV { get; set; }
    
        public virtual NhanVien NhanVien { get; set; }
    }
}
