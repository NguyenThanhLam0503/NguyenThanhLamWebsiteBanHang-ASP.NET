using PagedList;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteBanHang.Context;


namespace WebsiteBanHang.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        WebsiteASPEntities objWebsiteASPEntities = new WebsiteASPEntities();
        // GET: Admin/Category
        public ActionResult Index(string SearchString, string currentFilter, int? page)
        {
            var listCategory = new List<Category_2119110250>();
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
                listCategory = objWebsiteASPEntities.Category_2119110250.Where(x => x.CategoryName.Contains(SearchString) && x.Deleted == false).ToList();
            }
            else
            {
                //lấy ds sản phẩm trong bảng product
                listCategory = objWebsiteASPEntities.Category_2119110250.Where(x => x.Deleted == false).ToList();
            }
            ViewBag.CurrentFilter = SearchString;
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            //Sắp xếp sp theo id sản phẩm, sp mới đc đưa lên đầu
            listCategory = listCategory.OrderByDescending(x => x.CategoryId).ToList();
            return View(listCategory.ToPagedList(pageNumber, pageSize));
        }
        [HttpGet]
        public ActionResult Create()
        {
            //this.LoadData();
            return View();
        }


        public ActionResult Detail(int Id)
        {

            var objCategory = objWebsiteASPEntities.Category_2119110250.Where(n => n.CategoryId == Id).FirstOrDefault();
            return View(objCategory);
        }
        [HttpGet]
        public ActionResult Delete(int Id)
        {
            var objCategory = objWebsiteASPEntities.Category_2119110250.Where(a => a.CategoryId == Id).FirstOrDefault();
            return View(objCategory);
        }
        [HttpPost]
        public ActionResult Delete(Category_2119110250 objCat)
        {
            var objCate = objWebsiteASPEntities.Category_2119110250.Where(n => n.CategoryId == objCat.CategoryId).FirstOrDefault();
            //var objCategory = objWebsiteASPEntities.Category_2119110250.Where(n => n.CategoryId == objCat.CategoryId).FirstOrDefault();
            objWebsiteASPEntities.Category_2119110250.Remove(objCate);
            objWebsiteASPEntities.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int Id)
        {
            //this.LoadData();
            var objCategory = objWebsiteASPEntities.Category_2119110250.Where(n => n.CategoryId == Id).FirstOrDefault();
            return View(objCategory);
        }
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Edit(Category_2119110250 objCategory)
        {
            if (ModelState.IsValid)
            {
                //this.LoadData();
                if (objCategory.ImageUpLoad != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(objCategory.ImageUpLoad.FileName);
                    string extension = Path.GetExtension(objCategory.ImageUpLoad.FileName);
                    fileName = fileName + extension;
                    objCategory.Avatar = fileName;
                    objCategory.ImageUpLoad.SaveAs(Path.Combine(Server.MapPath("~/Content/images/product/"), fileName));
                }
                objWebsiteASPEntities.Entry(objCategory).State = EntityState.Modified;
                objWebsiteASPEntities.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(objCategory);
        }
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Create(Category_2119110250 objCategory)
        {
            if (ModelState.IsValid)
            {

                try
                {
                    if (objCategory.ImageUpLoad != null)
                    {
                        string fileName = Path.GetFileNameWithoutExtension(objCategory.ImageUpLoad.FileName);
                        string extension = Path.GetExtension(objCategory.ImageUpLoad.FileName);
                        fileName = fileName + extension;
                        objCategory.Avatar = fileName;
                        objCategory.ImageUpLoad.SaveAs(Path.Combine(Server.MapPath("~/Content/images/product/"), fileName));
                    }

                    objCategory.CreatedOnUtc = DateTime.Now;
                    objWebsiteASPEntities.Category_2119110250.Add(objCategory);
                    objWebsiteASPEntities.SaveChanges();

                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    return View();
                }

            }
            return View(objCategory);
        }
        //private void LoadData()
        //{
        //    Common objCommon = new Common();
        //    //lấy dữ liệu danh mục dưới DB
        //    var lstCat = objWebsiteASPEntities.Category_2119110250.ToList();
        //    //convert sang select list dạng  value, text
        //    ListtoDataTableConverter converter = new ListtoDataTableConverter();
        //    DataTable dtCategory = converter.ToDataTable(lstCat);
        //    ViewBag.ListCategory = objCommon.ToSelectList(dtCategory, "CategoryId", "CategoryName");

        //    //lấy dữ liệu thương hiệu dưới DB
        //    var lstBrand = objWebsiteASPEntities.Brand_2119110250.ToList();
        //    DataTable dtBrand = converter.ToDataTable(lstBrand);
        //    //convert sang select list dạng value, text
        //    ViewBag.ListBrand = objCommon.ToSelectList(dtBrand, "BrandId", "BrandName");



        //}
    }
}