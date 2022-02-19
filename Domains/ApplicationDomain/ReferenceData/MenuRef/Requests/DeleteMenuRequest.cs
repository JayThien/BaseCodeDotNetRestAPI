using ApplicationDomain.Common;
using ApplicationDomain.Entities;
using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDomain.ReferenceData.MenuRef.Requests
{
    public class DeleteMenuRequest : RequestBase
    {
        public int Id { set; get; }
    }

    public class DeleteMenuRequestValidator : AbstractValidator<DeleteMenuRequest>
    {
        public DeleteMenuRequestValidator()
        {
        }
    }

    public class DeleteMenuRequestMapper : Profile
    {
        public DeleteMenuRequestMapper()
        {
        }
    }
}
