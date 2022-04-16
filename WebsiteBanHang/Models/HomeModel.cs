using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebsiteBanHang.Context;
namespace WebsiteBanHang.Models
{
    public class HomeModel
    {
        public List<Product_2119110250> ListProduct { get; set; }
        public List<Category_2119110250> ListCategory { get; set; }
        public List<Brand_2119110250> ListBrand { get; set; }
    }
}