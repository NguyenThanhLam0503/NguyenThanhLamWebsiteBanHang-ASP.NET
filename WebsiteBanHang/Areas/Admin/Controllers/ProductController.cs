using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteBanHang.Context;
using WebsiteBanHang.Models;
using static WebsiteBanHang.Common;

namespace WebsiteBanHang.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        WebsiteASPEntities objWebsiteASPEntities = new WebsiteASPEntities();
        // GET: Admin/Product
        public ActionResult Index()
        {
            var lstProduct = objWebsiteASPEntities.Product_2119110250.ToList();
            return View(lstProduct);
        }
        [HttpGet]
        public ActionResult Create()
        {
            this.LoadData();
            return View();
        }


        public ActionResult Detail(int Id)
        {

            var objProduct = objWebsiteASPEntities.Product_2119110250.Where(n => n.Id == Id).FirstOrDefault();
            return View(objProduct);
        }
        [HttpGet]
        public ActionResult Delete(int Id)
        {
            var objProduct = objWebsiteASPEntities.Product_2119110250.Where(n => n.Id == Id).FirstOrDefault();
            return View(objProduct);
        }
        [HttpPost]
        public ActionResult Delete(Product_2119110250 objPro)
        {
            var objProduct = objWebsiteASPEntities.Product_2119110250.Where(n => n.Id == objPro.Id).FirstOrDefault();
            objWebsiteASPEntities.Product_2119110250.Remove(objProduct);
            objWebsiteASPEntities.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int Id)
        {
            this.LoadData();
            var objProduct = objWebsiteASPEntities.Product_2119110250.Where(n => n.Id == Id).FirstOrDefault();
            return View(objProduct);
        }
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Edit(Product_2119110250 objProduct)
        {
            this.LoadData();
            if (objProduct.ImageUpLoad != null)
            {
                string fileName = Path.GetFileNameWithoutExtension(objProduct.ImageUpLoad.FileName);
                string extension = Path.GetExtension(objProduct.ImageUpLoad.FileName);
                fileName = fileName + extension;
                objProduct.Avatar = fileName;
                objProduct.ImageUpLoad.SaveAs(Path.Combine(Server.MapPath("~/Content/images/product/"), fileName));
            }
            objProduct.DisPlayOrder = objProduct.Id;
            objProduct.Slug = ConvertSlug.Str_Slug(objProduct.Name);
            objWebsiteASPEntities.Entry(objProduct).State = EntityState.Modified;
            objWebsiteASPEntities.SaveChanges();
            return RedirectToAction("Index");
        }
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Create(Product_2119110250 objProduct)
        {
            this.LoadData();
            if (ModelState.IsValid)
            {

                try
                {
                    if (objProduct.ImageUpLoad != null)
                    {
                        string fileName = Path.GetFileNameWithoutExtension(objProduct.ImageUpLoad.FileName);
                        string extension = Path.GetExtension(objProduct.ImageUpLoad.FileName);
                        fileName = fileName + extension;
                        objProduct.Avatar = fileName;
                        objProduct.ImageUpLoad.SaveAs(Path.Combine(Server.MapPath("~/Content/images/product/"), fileName));
                    }
                    objProduct.Slug = ConvertSlug.Str_Slug(objProduct.Name);
                    objProduct.CreatedOnUtc = DateTime.Now;
                    objWebsiteASPEntities.Product_2119110250.Add(objProduct);
                    objWebsiteASPEntities.SaveChanges();

                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    return View();
                }

            }
            return View(objProduct);
        }
        private void LoadData()
        {
            Common objCommon = new Common();
            //lấy dữ liệu danh mục dưới DB
            var lstCat = objWebsiteASPEntities.Category_2119110250.ToList();
            //convert sang select list dạng  value, text
            ListtoDataTableConverter converter = new ListtoDataTableConverter();
            DataTable dtCategory = converter.ToDataTable(lstCat);
            ViewBag.ListCategory = objCommon.ToSelectList(dtCategory, "CategoryId", "CategoryName");

            //lấy dữ liệu thương hiệu dưới DB
            var lstBrand = objWebsiteASPEntities.Brand_2119110250.ToList();
            DataTable dtBrand = converter.ToDataTable(lstBrand);
            //convert sang select list dạng value, text
            ViewBag.ListBrand = objCommon.ToSelectList(dtBrand, "BrandId", "BrandName");

            //loại sản phẩm
            List<ProductType> lstProductType = new List<ProductType>();
            ProductType objProductType = new ProductType();
            objProductType.Id = 01;
            objProductType.Name = "Giảm giá sốc";
            lstProductType.Add(objProductType);

            objProductType = new ProductType();
            objProductType.Id = 02;
            objProductType.Name = "Đề xuất";
            lstProductType.Add(objProductType);

            DataTable dtProductType = converter.ToDataTable(lstProductType);
            //convert sang select list dạng value, text
            ViewBag.ProductType = objCommon.ToSelectList(dtProductType, "Id", "Name");
        }

    }
}