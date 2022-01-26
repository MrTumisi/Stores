using Stores.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace Stores.DataAccess.InMemory
{
    public class CategoryRepository 

    {
        ObjectCache cache = MemoryCache.Default;
        List<ProductCategory> ProductCategorys;
        public CategoryRepository()
        {
            ProductCategorys = cache["Category"] as List<ProductCategory>;
            if (ProductCategorys == null)
            {
                ProductCategorys = new List<ProductCategory>();
            }
        }

        public void Commit()
        {
            cache["Category"] = ProductCategorys;
        }

        public void Insert(ProductCategory pc)
        {
            ProductCategorys.Add(pc);
        }

        public void Update(ProductCategory ProductCategory)
        {
            ProductCategory productToUpdate = ProductCategorys.Find(pc => pc.Id == ProductCategory.Id);
            if (productToUpdate != null)
            {
                productToUpdate = ProductCategory;
            }
            else
            {
                throw new Exception("Category not Found");
            }
        }

        public ProductCategory Find(string Id)
        {
            ProductCategory ProductCategory = ProductCategorys.Find(p => p.Id == Id);
            if (ProductCategory != null)
            {
                return ProductCategory;
            }
            else
            {
                throw new Exception("Category not Found");
            }
        }

        public IQueryable<ProductCategory> Collection()
        {
            return ProductCategorys.AsQueryable();
        }

        public void Delete(string Id)
        {
            ProductCategory productToDelete = ProductCategorys.Find(p => p.Id == Id);
            if (productToDelete != null)
            {
                ProductCategorys.Remove(productToDelete);
            }
            else
            {
                throw new Exception("Product not Found");
            }
        }
    }
}
