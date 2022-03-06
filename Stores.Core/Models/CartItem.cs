using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stores.Core.Models
{
    public class CartItem : BaseEntity
    {
        public string CardId { get; set; }
        public string ProductId { get; set; }
        public int Quantity { get; set; }

    }
}
