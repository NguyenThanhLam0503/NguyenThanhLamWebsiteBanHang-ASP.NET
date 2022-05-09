using PagedList;
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
        public ActionResult Index(string SearchString, string currentFilter, int? page)
        {
            var listBrand = new List<Brand_2119110250>();
            if (SearchString != null)
            {
                page = 1;
            }
            else
            {
                SearchString = currentFilter;
            }
            if (!string.IsNullOrEmpty(SearchString))
            {
                //lấy ds sản phẩm theo từ khoá tìm kiếm
                listBrand = objWebsiteASPEntities.Brand_2119110250.Where(x => x.BrandName.Contains(SearchString) && x.Deleted == false).ToList();
            }
            else
            {
                //lấy ds sản phẩm trong bảng product
                listBrand = objWebsiteASPEntities.Brand_2119110250.Where(x => x.Deleted == false).ToList();
            }
            ViewBag.CurrentFilter = SearchString;
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            //Sắp xếp sp theo id sản phẩm, sp mới đc đưa lên đầu
            listBrand = listBrand.OrderByDescending(x => x.BrandId).ToList();
            return View(listBrand.ToPagedList(pageNumber, pageSize));
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
            if (ModelState.IsValid)
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
            return View(objBrand);
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