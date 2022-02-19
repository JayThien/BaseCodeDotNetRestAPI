using ApplicationDomain.Common;
using ApplicationDomain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDomain.ReferenceData.BaseProductRef.Responses
{
    public class DeleteBaseProductResponse : ResponseBase
    {
        public int Id { set; get; }
    }

    public class DeleteBaseProductReponseMapper : Profile
    {
        public DeleteBaseProductReponseMapper()
        {
        }
    }
}
