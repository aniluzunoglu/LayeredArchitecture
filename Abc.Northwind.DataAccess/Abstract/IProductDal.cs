using Abc.Core.DataAccess;
using Abc.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abc.Northwind.DataAccess.Abstract
{
    public interface IProductDal : IEntitiyRepository<Product>
    {
       // special methods related to product
    }
}
