using Stores.Core.Models;
using Stores.DataAccess.InMemory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Stores.UI.Controllers
{
    public class CategoryController : Controller
    {
        CategoryRepository context;
        public CategoryController()
        {
            context = new CategoryRepository();
        }
        // GET: Category
        public ActionResult Index()
        {
            List<ProductCategory> ProductCategorys = context.Collection().ToList();
            
            return View();
        }
        public ActionResult Create()
        {
            ProductCategory ProductCategory = new ProductCategory();
            return View(ProductCategory);
        }
        [HttpPost]
        public ActionResult Create(ProductCategory ProductCategory)
        {
            if (!ModelState.IsValid)
            {
                return View(ProductCategory);
            }
            else
            {
                context.Insert(ProductCategory);
                context.Commit();
                return RedirectToAction("Index");
            }
        }
        public ActionResult Edit(string Id)
        {
            ProductCategory ProductCategory = context.Find(Id);
            if (ProductCategory == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(ProductCategory);
            }
        }
        [HttpPost]
        public ActionResult Edit(ProductCategory ProductCategory, string Id)
        {
            ProductCategory prodC = context.Find(Id);
            if (prodC == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(ProductCategory);
                }

                prodC.Category = ProductCategory.Category;
                context.Commit();
                return RedirectToAction("Index");
            }
        }

        public ActionResult Delete(string Id)
        {
            ProductCategory productToDelete = context.Find(Id);
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
            ProductCategory productToDelete = context.Find(Id);
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