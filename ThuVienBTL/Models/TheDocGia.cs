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
    
    public partial class TheDocGia
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TheDocGia()
        {
            this.PhieuMuons = new HashSet<PhieuMuon>();
            this.PhieuTras = new HashSet<PhieuTra>();
        }
    
        public int MaThe { get; set; }
        public string HanThe { get; set; }
        public Nullable<System.DateTime> NgayDK { get; set; }
        public Nullable<System.DateTime> NgayHH { get; set; }
        public Nullable<int> TienThe { get; set; }
        public Nullable<int> MaNV { get; set; }
        public Nullable<int> MaDG { get; set; }
    
        public virtual DocGia DocGia { get; set; }
        public virtual NhanVien NhanVien { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhieuMuon> PhieuMuons { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhieuTra> PhieuTras { get; set; }
    }
}
