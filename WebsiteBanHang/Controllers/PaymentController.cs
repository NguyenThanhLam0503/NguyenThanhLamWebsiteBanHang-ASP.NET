using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteBanHang.Context;
using WebsiteBanHang.Models;

namespace WebsiteBanHang.Controllers
{
    public class PaymentController : Controller
    {
        WebsiteASPEntities objWebsiteASPEntities = new WebsiteASPEntities();
        // GET: Payment
        public ActionResult Index()
        {
            if (Session["idUser"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                //Lấy thông tin từ giỏ hàng từ biến session
                var lstCart = (List<CartModel>)Session["cart"];
                //Gán dữ liệu cho bảng Order
                Order_2119110250 objOrder = new Order_2119110250();
                objOrder.Name = "DonHang-" + DateTime.Now.ToString("yyyyMMddHHmmss");
                //objOrder.UserId = int.Parse(Session["Id"].ToString());
                objOrder.CreatedOnUtc = DateTime.Now;
                objOrder.Statut = 1;
                objWebsiteASPEntities.Order_2119110250.Add(objOrder);
                //Lưu thông tin
                objWebsiteASPEntities.SaveChanges();

                //Lấy OrderId vừa tạo mới để lưu vào bảng OrderDetail
                int intOrderId = objOrder.OrderId;
                List<OrderDetail_2119110250> listOrderDetail = new List<OrderDetail_2119110250>();
                foreach (var item in lstCart)
                {
                    OrderDetail_2119110250 objDetail = new OrderDetail_2119110250();
                    objDetail.OrderDetailId = objOrder.OrderId + 1;
                    objDetail.Quantity = item.Quantity;
                    objDetail.OrderId = intOrderId;
                    objDetail.ProductId = item.Product.Id;
                    listOrderDetail.Add(objDetail);
                }
                objWebsiteASPEntities.OrderDetail_2119110250.AddRange(listOrderDetail);
                //Lưu thông tin
                objWebsiteASPEntities.SaveChanges();

                //Session;

            }
            return View();
        }
    }
}