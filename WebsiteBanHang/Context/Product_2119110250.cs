﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebsiteBanHang.Context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Web;

    public partial class Product_2119110250
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập tên")]
        [Display(Name = "Tên Sản Phẩm")]
        public string Name { get; set; }
        [Display(Name = "Hình ảnh")]
        public string Avatar { get; set; }
        [Display(Name = "Danh mục")]
        public Nullable<int> CategoryId { get; set; }
        [Display(Name = "Thương hiệu")]
        public Nullable<int> BrandId { get; set; }
        [Display(Name = "Mô tả")]
        public string ShoetDes { get; set; }
        [Display(Name = "Chi tiết")]
        public string FullDescription { get; set; }
        [Display(Name = "Giá")]
        public Nullable<double> Price { get; set; }
        [Display(Name = "Giá khuyến mãi")]
        public Nullable<double> PriceDiscount { get; set; }
        [Display(Name = "Loại")]
        public Nullable<int> TypeId { get; set; }
        public string Slug { get; set; }
        [Display(Name = "Xoá Sản phẩm")]
        public Nullable<bool> Deleted { get; set; }
        [Display(Name = "Hiện trên Trang chủ")]
        public Nullable<bool> ShowOnHomePage { get; set; }
        [Display(Name = "Thứ tự xuất hiện")]
        public Nullable<int> DisPlayOrder { get; set; }
        [Display(Name = "Ngày tạo")]
        public Nullable<System.DateTime> CreatedOnUtc { get; set; }
        [Display(Name = "Ngày cập nhật")]
        public Nullable<System.DateTime> UpdatedOnUtc { get; set; }
        [NotMapped]
        public HttpPostedFileBase ImageUpLoad { get; set; }
    }
}
