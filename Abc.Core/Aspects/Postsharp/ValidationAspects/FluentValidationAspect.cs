using Abc.Core.CrossCuttingConcerns.Validation.FluentValidation;
using FluentValidation;
using PostSharp.Aspects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abc.Core.Aspects.Postsharp.ValidationAspects
{
    [Serializable]
    public class FluentValidationAspect: OnMethodBoundaryAspect
    {
        Type _validatorType;
        public FluentValidationAspect(Type validatorType)
        {
            _validatorType = validatorType;
        }
        public override void OnEntry(MethodExecutionArgs args)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType);
            // For example in the productManager under businessLayer we sent type of ProductValidator as following;
            //   [FluentValidationAspect(typeof(ProductValidator))]
            // Hence, this validator is an instance of ProductValidator.

            var entityType = _validatorType.BaseType.GetGenericArguments()[0];
            // since we did not send any entity type in "[FluentValidationAspect(typeof(ProductValidator))]" we need to know the entity type.
            // _validatorType -> ProductValidator
            // In our example " public class ProductValidator : AbstractValidator<Product> " =>  _validatorType.BaseType is AbstractValidator.
            // since AbstractValidator has a generic argument (public abstract class AbstractValidator<T>), we use GetGenericArguments method.
            // finally we get "Product" entity as a result of _validatorType.BaseType.GetGenericArguments()[0] 

            var entities = args.Arguments.Where(c => c.GetType() == entityType);
            // args contains method information.
            // we want to get methods parameters where the type of validator and method parameter are the same.
            // in our example, public void Add(Product product) / public class ProductValidator : AbstractValidator<Product>
            // Method parameter product Type = "Product" 
            // Validator parameter Type = "Product"


            foreach (var entity in entities)
            {
                ValidationTool.FluentValidate(validator, entity);
            }
        }
    }
}
