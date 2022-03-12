using Stores.Core.Contracts;
using Stores.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Stores.UI.Controllers
{
    public class OrderController : Controller
    {
        IOrderService orderService;
        public OrderController(IOrderService OrderService)
        {
            this.orderService = OrderService;
        }
        public ActionResult Index()
        {
            List<Order> orders = orderService.GetOrderslist();
            return View(orders);
        }
        public ActionResult UpdateOrder(string Id)
        {
            Order order = orderService.GetOrder(Id);
            return View(order);
        }
        [HttpPost]
        public ActionResult UpdateOrder(Order updateOrder, string Id)
        {
            Order order = orderService.GetOrder(Id);
            order.OrderStatus = updateOrder.OrderStatus;
            orderService.UpdateOrder(order);
            return RedirectToAction("Index");
        }
    }
}