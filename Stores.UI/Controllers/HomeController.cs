using Stores.Core.Contracts;
using Stores.Core.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Stores.Core.viewmodel;

namespace Stores.UI.Controllers
{
    public class HomeController : Controller
    {
        IRepository<Product> context;
        IRepository<ProductCategory> productCatrgories;
        public HomeController(IRepository<Product> productContext, IRepository<ProductCategory> categoryContext)
        {
            context = productContext;
            productCatrgories = categoryContext;
        }
        public ActionResult Index( string Category = null)
        {
            List<Product> products = context.Collection().ToList();
            List<ProductCategory> categories = productCatrgories.Collection().ToList();
            if(Category == null)
            {
               products = context.Collection().ToList();
            }
            else
            {
                products = context.Collection().Where(p => p.Category == Category).ToList();
            }
            ProductListVM model = new ProductListVM();
            model.Products = products;
            model.ProductCategorys = categories;
            return View(products);
        }

        public ActionResult Details(string Id)
        {
            Product product = context.Find(Id);
            if(product == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(product);
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}