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
    using System.ComponentModel.DataAnnotations;

    public partial class DANHGIA
    {
        public string MaDG { get; set; }
        public string MaKH { get; set; }
        public string MaQA { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public System.DateTime NgayDG { get; set; }
        public string DanhGia1 { get; set; }
    
        public virtual KHACHHANG KHACHHANG { get; set; }
        public virtual QUANAO QUANAO { get; set; }
    }
}