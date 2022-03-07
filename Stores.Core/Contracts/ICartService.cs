using Stores.Core.Viewmodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Stores.Core.Contracts
{
    public interface ICartService
    {
        void AddToCart(HttpContextBase httpContext, string productId);
        void RemoveFromCart(HttpContextBase httpContext, string itemId);
        List<CartItemVM> GetCartItems(HttpContextBase httpContext);
        CartSummaryVM GetCartSummary(HttpContextBase httpContext);
    }
}
