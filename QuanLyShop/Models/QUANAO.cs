//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QuanLyShop.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class QUANAO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public QUANAO()
        {
            this.CHITIETHDs = new HashSet<CHITIETHD>();
            this.DANHGIAs = new HashSet<DANHGIA>();
        }
    
        public string MaQA { get; set; }
        public string MaLoHang { get; set; }
        public string TenQuanAo { get; set; }
        public string Size { get; set; }
        public int GiaSanPham { get; set; }
        public string MauSac { get; set; }
        public string AnhMinhHoa { get; set; }
        public string NoiSX { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETHD> CHITIETHDs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DANHGIA> DANHGIAs { get; set; }
        public virtual KHO KHO { get; set; }
    }
}
