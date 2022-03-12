using Stores.Core.Contracts;
using Stores.Core.Models;
using Stores.Core.Viewmodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stores.Services
{
    public class OrderService : IOrderService
    {
        IRepository<Order> orderContext;
        public OrderService(IRepository<Order> OrderContext)
        {
            this.orderContext = OrderContext;
        }

        public void CreateOrder(Order baseOrder, List<CartItemVM> cartItems)
        {
            foreach(var item in cartItems)
            {
                baseOrder.OrderItems.Add(new OrderItem()
                {
                    ProductId = item.Id,
                    Image = item.Image,
                    Price = item.Price,
                    ProductName = item.ProductName,
                    Quantity = item.Quantity

                });
            }
            orderContext.Insert(baseOrder);
            orderContext.Commit();
        }
        public List<Order> GetOrderslist()
        {
            return orderContext.Collection().ToList();
        }
        public Order GetOrder(string Id)
        {
            return orderContext.Find(Id);
        }
        public void UpdateOrder(Order updateOrder)
        {
            orderContext.Update(updateOrder);
            orderContext.Commit();
        }
    }
}
