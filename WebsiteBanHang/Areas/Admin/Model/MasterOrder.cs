using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebsiteBanHang.Context;

namespace WebsiteBanHang.Areas.Admin.Model
{
    public class MasterOrder
    {
        public new List<Order_2119110250> ListOrder { get; set; }
        public new List<OrderDetail_2119110250> ListOrderDetail { get; set; }
        public new List<User_2119110250> ListUser { get; set; }
    }
}