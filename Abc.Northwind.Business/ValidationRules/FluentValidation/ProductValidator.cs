using Abc.Northwind.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abc.Northwind.Business.ValidationRules.FluentValidation
{
    public class ProductValidator : AbstractValidator<Product>
    {

        // Validation is checking for the entity coming from the user, if the entity is suitable for our business purposes.
        // for example productName is required, price should be greater than 0

        public ProductValidator()
        {
            RuleFor(c=>c.ProductName).NotEmpty();
            RuleFor(c=>c.CategoryId).NotEmpty();
            RuleFor(c=>c.UnitPrice).NotEmpty();
            RuleFor(c=>c.UnitPrice).GreaterThan(0);
            RuleFor(c=>c.UnitPrice).GreaterThan(10).When(c=>c.CategoryId==1);
            RuleFor(c => c.ProductName).Must(StartWithA).WithMessage("Product Name should start with A"); // .Must receives a delegate. A delegate is address holder of method.
        }

        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");
        }


    }
}
