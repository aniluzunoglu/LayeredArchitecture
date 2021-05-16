using Abc.Northwind.Business.Abstract;
using Abc.Northwind.Business.Concrete;
using Abc.Northwind.DataAccess.Concrete.EntitiyFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abc.Northwind.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            // TO DO: refactor IOC 
            IProductService productService = new ProductManager(new EfProductDal());
            foreach (var product in productService.GetAll())
            {
                Console.WriteLine(product.ProductName);
            }

            Console.ReadLine();
        }
    }
}
