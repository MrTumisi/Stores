using Stores.Core.Models;
using Stores.Core.Viewmodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stores.Core.Contracts
{
    public interface IOrderService

    {
        void CreateOrder(Order baseOrder, List<CartItemVM> cartItems);
        List<Order> GetOrderslist();
        Order GetOrder(string Id);
        void UpdateOrder(Order updateOrder);
    }
}
