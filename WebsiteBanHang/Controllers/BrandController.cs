using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteBanHang.Context;

namespace WebsiteBanHang.Controllers
{
    public class BrandController : Controller
    {
        WebsiteASPEntities objWebsiteASPEntities = new WebsiteASPEntities();
        // GET: Brand
        public ActionResult Index()
        {
            var lstBrand = objWebsiteASPEntities.Brand_2119110250.ToList();
            return View(lstBrand);
        }
    } 
}