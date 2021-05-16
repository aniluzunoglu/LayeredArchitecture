using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abc.Core.CrossCuttingConcerns.Validation.FluentValidation
{
    public static class ValidationTool
    {

        // I want to create a tool which can take a validator and then validate the entity or model we sent.
        // CrossCuttingConcern is a standart for validation, caching, logging, authorization and similar things that we can use in different layers.
        // For example, you can create clientside valitation(js validation) in user interface, 
        // than create a backend validation that you could use in business layer.
        // Thats why we created the CrossCuttingConcerns folder.

        public static void FluentValidate(IValidator validator, object entity) // since all entities in C# are derived from Object we use object here.
        {
            var context = new ValidationContext<object>(entity);            
            var result = validator.Validate(context);

            if (result.Errors.Count>0)
            {
                throw new ValidationException(result.Errors);
            }
        }
    }
}
