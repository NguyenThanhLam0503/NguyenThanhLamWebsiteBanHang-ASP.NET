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
    public class UserController : Controller
    {
        WebsiteASPEntities objWebsiteASPEntities = new WebsiteASPEntities();
        // GET: Admin/News
        public ActionResult Index(string currenFilter, string SearchString, int? page)
        {
            var lstUser = new List<User_2119110250>();
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
                lstUser = objWebsiteASPEntities.User_2119110250.Where(n => n.FirstName.Contains(SearchString)).ToList();
            }
            else
            {
                lstUser = objWebsiteASPEntities.User_2119110250.ToList();
            }
            ViewBag.currenFilter = SearchString;
            int pageSize = 4;
            int pageNumber = (page ?? 1);
            lstUser = lstUser.OrderByDescending(n => n.UserId).ToList();
            return View(lstUser.ToPagedList(pageNumber, pageSize));
        }

        [HttpGet]
        public ActionResult Detail(int id)
        {
            var objUser = objWebsiteASPEntities.User_2119110250.Where(n => n.UserId == id).FirstOrDefault();
            return View(objUser);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var objUser = objWebsiteASPEntities.User_2119110250.Where(n => n.UserId == id).FirstOrDefault();
            return View(objUser);
        }
        [HttpPost]
        public ActionResult Delete(User_2119110250 objUsers, int Id)
        {
            objUsers.UserId = Id;
            var objUser = objWebsiteASPEntities.New_2119110250.Where(n => n.NewId == objUsers.UserId).FirstOrDefault();
            objWebsiteASPEntities.User_2119110250.Remove(objUsers);
            objWebsiteASPEntities.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var objUser = objWebsiteASPEntities.User_2119110250.Where(n => n.UserId == id).FirstOrDefault();
            return View(objUser);
        }
        [HttpPost]
        public ActionResult Edit(int id, User_2119110250 objUser)
        {
            objWebsiteASPEntities.Entry(objUser).State = EntityState.Modified;
            objWebsiteASPEntities.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}