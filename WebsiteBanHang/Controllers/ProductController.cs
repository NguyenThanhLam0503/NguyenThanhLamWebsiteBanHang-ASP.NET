using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteBanHang.Context;
using WebsiteBanHang.Models;

namespace WebsiteBanHang.Controllers
{
    public class ProductController : Controller
    {
        WebsiteASPEntities objWebsiteASPEntities = new WebsiteASPEntities();
        // GET: Product
        public ActionResult Detail(int id)
        { 
            var objProduct = objWebsiteASPEntities.Product_2119110250.Where(a => a.Id == id).FirstOrDefault();
            return View(objProduct);
        }
        public ActionResult CategoryList(int id)
        {
            //Lấy sản phẩm theo category
            //Lấy danh mục 
            var objCate = objWebsiteASPEntities.Category_2119110250.Where(n => n.CategoryId == id).FirstOrDefault();
            //var lstBrand = objWebsiteASPEntities.Brand_2119110250.ToList();
            CategoryProduct objCategoryProduct = new CategoryProduct();
            objCategoryProduct.Id = id;
            objCategoryProduct.listProduct = objWebsiteASPEntities.Product_2119110250.Where(n => n.CategoryId == id && n.Deleted == false).ToList();
            objCategoryProduct.objCategory = objCate;
            //objCategoryProduct.listBrand = lstBrand;

            return View(objCategoryProduct);
            //List<Product_2119110250> lstProduct = new List<Context.Product_2119110250>();
            //lstProduct = objWebsiteASPEntities.Product_2119110250.ToList();
            //var lstProductToCate = objWebsiteASPEntities.Product_2119110250.Where(a=>a.CategoryId==id).ToList();
            //var lstCategory = objWebsiteASPEntities.Category_2119110250.Where(a => a.CategoryId == id).ToList();
            //CategoryProduct objCategoryProduct = new CategoryProduct();
            //objCategoryProduct.listProduct = lstProductToCate;
            //objCategoryProduct.listCategory = lstCategory;
            //return View(objCategoryProduct);
           
        }
        public ActionResult BrandList(int id)
        {
            var lstProductToBrand = objWebsiteASPEntities.Product_2119110250.Where(a => a.BrandId == id).ToList();
            var lstBrand = objWebsiteASPEntities.Brand_2119110250.Where(a => a.BrandId == id).ToList();
            BrandProduct objBrandProduct = new BrandProduct();
            objBrandProduct.listProduct = lstProductToBrand;
            objBrandProduct.listBrand = lstBrand;
            return View(objBrandProduct);
        }
    }
}