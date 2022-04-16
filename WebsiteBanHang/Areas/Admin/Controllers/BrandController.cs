using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteBanHang.Context;

namespace WebsiteBanHang.Areas.Admin.Controllers
{
    public class BrandController : Controller
    {
        WebsiteASPEntities objWebsiteASPEntities = new WebsiteASPEntities();
        // GET: Admin/Category
        public ActionResult Index()
        {
            var lstBrand = objWebsiteASPEntities.Brand_2119110250.ToList();
            return View(lstBrand);
        }
        [HttpGet]
        public ActionResult Create()
        {
            //this.LoadData();
            return View();
        }


        public ActionResult Detail(int Id)
        {

            var objBrand = objWebsiteASPEntities.Brand_2119110250.Where(n => n.BrandId == Id).FirstOrDefault();
            return View(objBrand);
        }
        [HttpGet]
        public ActionResult Delete(int Id)
        {
            var objBrand = objWebsiteASPEntities.Brand_2119110250.Where(a => a.BrandId == Id).FirstOrDefault();
            return View(objBrand);
        }
        [HttpPost]
        public ActionResult Delete(Brand_2119110250 objBra)
        {
            var objBran = objWebsiteASPEntities.Category_2119110250.Where(n => n.CategoryId == objBra.BrandId).FirstOrDefault();
            //var objCategory = objWebsiteASPEntities.Category_2119110250.Where(n => n.CategoryId == objCat.CategoryId).FirstOrDefault();
            objWebsiteASPEntities.Category_2119110250.Remove(objBran);
            objWebsiteASPEntities.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int Id)
        {
            //this.LoadData();
            var objBrand = objWebsiteASPEntities.Brand_2119110250.Where(n => n.BrandId == Id).FirstOrDefault();
            return View(objBrand);
        }
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Edit(Brand_2119110250 objBrand)
        {
            //this.LoadData();
            if (objBrand.ImageUpLoad != null)
            {
                string fileName = Path.GetFileNameWithoutExtension(objBrand.ImageUpLoad.FileName);
                string extension = Path.GetExtension(objBrand.ImageUpLoad.FileName);
                fileName = fileName + extension;
                objBrand.Avatar = fileName;
                objBrand.ImageUpLoad.SaveAs(Path.Combine(Server.MapPath("~/Content/images/product/"), fileName));
            }
            objWebsiteASPEntities.Entry(objBrand).State = EntityState.Modified;
            objWebsiteASPEntities.SaveChanges();
            return RedirectToAction("Index");
        }
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Create(Brand_2119110250 objBrand)
        {
            if (ModelState.IsValid)
            {

                try
                {
                    if (objBrand.ImageUpLoad != null)
                    {
                        string fileName = Path.GetFileNameWithoutExtension(objBrand.ImageUpLoad.FileName);
                        string extension = Path.GetExtension(objBrand.ImageUpLoad.FileName);
                        fileName = fileName + extension;
                        objBrand.Avatar = fileName;
                        objBrand.ImageUpLoad.SaveAs(Path.Combine(Server.MapPath("~/Content/images/product/"), fileName));
                    }

                    objBrand.CreatedOnUtc = DateTime.Now;
                    objWebsiteASPEntities.Brand_2119110250.Add(objBrand);
                    objWebsiteASPEntities.SaveChanges();

                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    return View();
                }

            }
            return View(objBrand);
        }
    }
}