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
    
    public partial class CHITIETHD
    {
        public string MaCTHD { get; set; }
        public string MaHD { get; set; }
        public string MaQA { get; set; }
        public int SoLuong { get; set; }
        public int DonGia { get; set; }
    
        public virtual HOADON HOADON { get; set; }
        public virtual QUANAO QUANAO { get; set; }
    }
}
