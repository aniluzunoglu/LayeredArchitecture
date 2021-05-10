using Abc.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abc.Northwind.DataAccess.Concrete.EntitiyFramework.Mappings
{
    public class ProductMap : EntityTypeConfiguration<Product>
    {
        public ProductMap()
        {
            ToTable(@"Products",@"dbo");
            HasKey(c => c.ProductId);

            Property(c => c.ProductId).HasColumnName("ProductID");
            Property(c => c.ProductName).HasColumnName("ProductName");
            Property(c => c.QuantityPerUnit).HasColumnName("QuantityPerUnit");
            Property(c => c.UnitPrice).HasColumnName("UnitPrice");
            Property(c => c.UnitsInStock).HasColumnName("UnitsInStock");

        }
    }
}
