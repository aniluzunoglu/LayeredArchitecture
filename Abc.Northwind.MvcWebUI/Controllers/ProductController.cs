using Abc.Northwind.Business.Abstract;
using Abc.Northwind.Business.Concrete;
using Abc.Northwind.DataAccess.Concrete.EntitiyFramework;
using Abc.Northwind.MvcWebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Abc.Northwind.MvcWebUI.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            // TO DO: refactor IOC 
            IProductService productService = new ProductManager(new EfProductDal());
            var model = new ProductListViewModel()
            {
                Products = productService.GetAll()
            };

            return View(model);
        }
    }
}