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
    public class NewController : Controller
    {
        // GET: Admin/New
        WebsiteASPEntities objWebsiteASPEntities = new WebsiteASPEntities();
        // GET: Admin/News
        public ActionResult Index(string currenFilter, string SearchString, int? page)
        {
            var lstNew = new List<New_2119110250>();
            if (SearchString != null)
            {
                page = 1;
            }
            else
            {
                SearchString = currenFilter;
            }
            if (!string.IsNullOrEmpty(SearchString))
            {
                lstNew = objWebsiteASPEntities.New_2119110250.Where(n => n.NewName.Contains(SearchString)).ToList();
            }
            else
            {
                lstNew = objWebsiteASPEntities.New_2119110250.ToList();
            }
            ViewBag.currenFilter = SearchString;
            int pageSize = 4;
            int pageNumber = (page ?? 1);
            lstNew = lstNew.OrderByDescending(n => n.NewId).ToList();
            return View(lstNew.ToPagedList(pageNumber, pageSize));
        }
        [HttpGet]
        public ActionResult Create()
        {

            return View();
        }
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Create(New_2119110250 objNew)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    if (objNew.ImageUpLoad != null)
                    {
                        string fileName = Path.GetFileNameWithoutExtension(objNew.ImageUpLoad.FileName);
                        string extension = Path.GetExtension(objNew.ImageUpLoad.FileName);
                        fileName = fileName + extension;
                        objNew.Avatar = fileName;
                        objNew.ImageUpLoad.SaveAs(Path.Combine(Server.MapPath("~/Content/images/product/"), fileName));
                    }
                    objNew.CreateOnUtc = DateTime.Now;
                    objWebsiteASPEntities.New_2119110250.Add(objNew);
                    objWebsiteASPEntities.SaveChanges();

                    return RedirectToAction("Index");
                }

                catch
                {
                    return View();
                }

            }
            return View(objNew);
        }

        [HttpGet]
        public ActionResult Detail(int id)
        {
            var objNew = objWebsiteASPEntities.New_2119110250.Where(n => n.NewId == id).FirstOrDefault();
            return View(objNew);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var objNew = objWebsiteASPEntities.New_2119110250.Where(n => n.NewId == id).FirstOrDefault();
            return View(objNew);
        }
        [HttpPost]
        public ActionResult Delete(New_2119110250 objNews, int Id)
        {
            objNews.NewId =  Id ;
            var objNew = objWebsiteASPEntities.New_2119110250.Where(n => n.NewId == objNews.NewId).FirstOrDefault();
            objWebsiteASPEntities.New_2119110250.Remove(objNew);
            objWebsiteASPEntities.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var objNews = objWebsiteASPEntities.New_2119110250.Where(n => n.NewId == id).FirstOrDefault();
            return View(objNews);
        }
        [HttpPost]
        public ActionResult Edit(int id, New_2119110250 objNews)
        {
            if (ModelState.IsValid)
            {
                if (objNews.ImageUpLoad != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(objNews.ImageUpLoad.FileName);
                    string extension = Path.GetExtension(objNews.ImageUpLoad.FileName);
                    fileName = fileName + extension;
                    objNews.Avatar = fileName;
                    objNews.ImageUpLoad.SaveAs(Path.Combine(Server.MapPath("~/Content/images/product/"), fileName));
                }
                objWebsiteASPEntities.Entry(objNews).State = EntityState.Modified;
                objWebsiteASPEntities.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(objNews);
        }
    }
}