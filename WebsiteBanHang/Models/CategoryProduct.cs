using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebsiteBanHang.Context;

namespace WebsiteBanHang.Models
{
    public class CategoryProduct
    {

        public int Id { get; set; }
        public List<Product_2119110250> listProduct { get; set; }
        public Category_2119110250 objCategory { get; set; }
        public List<Brand_2119110250> listBrand { get; set; }
    }
}