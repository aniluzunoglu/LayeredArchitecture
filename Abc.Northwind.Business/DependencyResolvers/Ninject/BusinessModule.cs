using Abc.Northwind.Business.Abstract;
using Abc.Northwind.Business.Concrete;
using Abc.Northwind.DataAccess.Abstract;
using Abc.Northwind.DataAccess.Concrete.EntitiyFramework;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abc.Northwind.Business.DependencyResolvers.Ninject
{
    public class BusinessModule : NinjectModule
    {
        public override void Load()
        {
            // when someone wants a IProductService, ninject will give him a ProductManager instance.
            // ProductManager productManager = new ProductManager();
            // since interfaces are reference types, one interface can hold another reference which implements that interface. 
            // By doing that, we do not create instances over and over again, thus we optimize memory usage

            Bind<IProductService>().To<ProductManager>();
            // when someone wants a IProductDal, ninject will give him a EfProductDal instance.
            // in future, when we want to switch to NH from EF, only thing we should do is change here. (NhProductDal)
            Bind<IProductDal>().To<EfProductDal>();
        }
    }
}
