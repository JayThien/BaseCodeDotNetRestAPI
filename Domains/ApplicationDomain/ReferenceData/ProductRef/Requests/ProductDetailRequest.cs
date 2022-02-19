using ApplicationDomain.Common;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDomain.ReferenceData.ProductRef.Requests
{
    public class ProductDetailRequest : RequestBase
    {
        public int Id { set; get; }
    }
    public class ProductDetailRequestValidator: AbstractValidator<ProductDetailRequest>
    {
        public ProductDetailRequestValidator()
        {
            RuleFor(p => p.Id).NotEmpty();
            RuleFor(p => p.Id).NotNull();
            RuleFor(p => p.Id).GreaterThan(0);
        }
    }
}
