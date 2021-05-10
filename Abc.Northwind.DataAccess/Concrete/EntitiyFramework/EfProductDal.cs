using Abc.Northwind.DataAccess.Abstract;
using Abc.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abc.Northwind.DataAccess.Concrete.EntitiyFramework
{
    public class EfProductDal : IProductDal
    {
        public List<Product> GetList()
        {
            throw new NotImplementedException();
        }
    }
}
