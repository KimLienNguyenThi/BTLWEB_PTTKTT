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
    
    public partial class LOGIN_DG
    {
        public string USERNAME_DG { get; set; }
        public string PASSWORD_DG { get; set; }
        public string HoTen_DG { get; set; }
        public Nullable<int> MaDG { get; set; }
    
        public virtual DocGia DocGia { get; set; }
    }
}
