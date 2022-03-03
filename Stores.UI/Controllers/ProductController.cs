using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Stores.Core.Contracts;
using Stores.Core.Models;
using Stores.Core.viewmodel;
using Stores.DataAccess.InMemory;

namespace Stores.UI.Controllers
{
    public class ProductController : Controller
    {
        IRepository<Product> context;
        IRepository<ProductCategory> productCatrgories;
        public ProductController(IRepository<Product> productContext, IRepository<ProductCategory> categoryContext)
        {
            context = productContext;
            productCatrgories = categoryContext;
        }
        // GET: Product
        public ActionResult Index()
        {
            List<Product> products = context.Collection().ToList();
            return View(products);
        }
        public ActionResult Create()
        {
            ProductVM viewmodel = new ProductVM();
            viewmodel.product = new Product();
            viewmodel.ProductCategorys = productCatrgories.Collection();
            return View(viewmodel);   
        }
        [HttpPost]
        public ActionResult Create(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            else
            {
                context.Insert(product);
                context.Commit();
                return RedirectToAction("Index");
            }
        }
        public ActionResult Edit(string Id)
        {
            Product product = context.Find(Id);
            if (product == null)
            {
                return HttpNotFound();
            }
            else
            {
                ProductVM viewmodel = new ProductVM();
                viewmodel.product = product;
                viewmodel.ProductCategorys = productCatrgories.Collection();
                return View(viewmodel);
            }
        }
        [HttpPost]
        public ActionResult Edit(Product product, string Id)
        {
            Product prod = context.Find(Id);
            if (prod == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(product);
                }
                prod.Description = product.Description;
                prod.Name = product.Name;
                prod.Price = product.Price;
                prod.Category = product.Category;
                prod.Image = product.Image;
                context.Commit();
                return RedirectToAction("Index");
            }
        }

        public ActionResult Delete(string Id)
        {
            Product productToDelete = context.Find(Id);
            if (productToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(productToDelete);
            }
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string Id)
        {
            Product productToDelete = context.Find(Id);
            if (productToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                context.Delete(Id);
                context.Commit();
                return RedirectToAction("Index");
            }
        }
    }
}