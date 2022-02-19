using ApplicationDomain.Common;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDomain.ReferenceData.MenuRef.Requests
{
    public class MenuDetailRequest : RequestBase
    {
        public int Id { set; get; }
    }
    public class MenuDetailRequestValidator: AbstractValidator<MenuDetailRequest>
    {
        public MenuDetailRequestValidator()
        {
            RuleFor(p => p.Id).NotEmpty();
            RuleFor(p => p.Id).NotNull();
            RuleFor(p => p.Id).GreaterThan(0);
        }
    }
}
