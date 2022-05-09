using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteBanHang.Areas.Admin.Model;
using WebsiteBanHang.Context;

namespace WebsiteBanHang.Areas.Admin.Controllers
{
    public class OrderController : Controller
    {
        WebsiteASPEntities objWebsiteASPEntities = new WebsiteASPEntities();
        // GET: Admin/Order
        public ActionResult Index()
        {
            MasterOrder master = new MasterOrder();
            master.ListOrder = objWebsiteASPEntities.Order_2119110250.ToList();
            master.ListOrderDetail = objWebsiteASPEntities.OrderDetail_2119110250.ToList();

            return View(master);
        }

    }
}