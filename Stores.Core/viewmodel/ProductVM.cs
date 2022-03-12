using Stores.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stores.Core.Viewmodel
{
    public class ProductVM
    {
        public Product product { get; set; }
        public IEnumerable<ProductCategory> ProductCategorys { get; set; }  
    }
}
