using ApplicationDomain.Common;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDomain.ReferenceData.BaseProductRef.Requests
{
    public class BaseProductDetailRequest : RequestBase
    {
        public int Id { set; get; }
    }
    public class BaseProductDetailRequestValidator: AbstractValidator<BaseProductDetailRequest>
    {
        public BaseProductDetailRequestValidator()
        {
            RuleFor(p => p.Id).NotEmpty();
            RuleFor(p => p.Id).NotNull();
            RuleFor(p => p.Id).GreaterThan(0);
        }
    }
}
