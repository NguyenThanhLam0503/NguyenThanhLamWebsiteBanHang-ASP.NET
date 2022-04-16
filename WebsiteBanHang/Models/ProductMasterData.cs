using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebsiteBanHang.Models
{
    public class ProductMasterData
    {
        public int Id { get; set; }
        [Display(Name= "Tên")]
        public string Name { get; set; }
        [Display(Name = "Hình ảnh")]
        public string Avatar { get; set; }
        [Display(Name = "Danh mục")]
        public Nullable<int> CategoryId { get; set; }
        [Display(Name = "Thương hiệu")]
        public Nullable<int> BrandId { get; set; }
        [Display(Name = "Mô tả")]
        public string ShoetDes { get; set; }
        public string FullDescription { get; set; }
        public Nullable<double> Price { get; set; }
        public Nullable<double> PriceDiscount { get; set; }
        public Nullable<int> TypeId { get; set; }
        public string Slug { get; set; }
        public Nullable<bool> Deleted { get; set; }
        public Nullable<bool> ShowOnHomePage { get; set; }
        public Nullable<int> DisPlayOrder { get; set; }
        public Nullable<System.DateTime> CreatedOnUtc { get; set; }
        public Nullable<System.DateTime> UpdatedOnUtc { get; set; }
        [NotMapped]
        public System.Web.HttpPostedFileBase ImageUpLoad { get; set; }
    }
}