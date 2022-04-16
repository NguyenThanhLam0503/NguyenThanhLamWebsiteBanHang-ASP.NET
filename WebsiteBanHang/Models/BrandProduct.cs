using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteBanHang.Context;

namespace WebsiteBanHang.Models
{
    public class BrandProduct : Controller
    {
        public List<Product_2119110250> listProduct { get; set; }
        public List<Brand_2119110250> listBrand { get; set; }
    }
}