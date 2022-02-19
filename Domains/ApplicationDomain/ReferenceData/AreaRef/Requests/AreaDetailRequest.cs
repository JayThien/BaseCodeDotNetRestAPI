using ApplicationDomain.Common;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDomain.ReferenceData.AreaRef.Requests
{
    public class AreaDetailRequest : RequestBase
    {
        public int Id { set; get; }
    }
    public class AreaDetailRequestValidator: AbstractValidator<AreaDetailRequest>
    {
        public AreaDetailRequestValidator()
        {
            RuleFor(p => p.Id).NotEmpty();
            RuleFor(p => p.Id).NotNull();
            RuleFor(p => p.Id).GreaterThan(0);
        }
    }
}
