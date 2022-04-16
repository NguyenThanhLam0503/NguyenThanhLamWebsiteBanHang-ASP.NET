using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteBanHang.Context;

namespace WebsiteBanHang.Controllers
{
    public class CategoryController : Controller
    {
        WebsiteASPEntities objWebsiteASPEntities = new WebsiteASPEntities();
        // GET: Category
        public ActionResult Index()
        {
            var lstCategory = objWebsiteASPEntities.Category_2119110250.ToList();
            return View(lstCategory);
        }
    }
}