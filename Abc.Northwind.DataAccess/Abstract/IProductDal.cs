﻿using Abc.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abc.Northwind.DataAccess.Abstract
{
    public interface IProductDal
    {
        List<Product> GetList();
    }
}
