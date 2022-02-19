using ApplicationDomain.Common;
using ApplicationDomain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDomain.ReferenceData.ProductRef.Responses
{
    public class UpdateProductResponse : ResponseBase
    {
        public int Id { set; get; }
    }

    public class UpdateProductReponseMapper : Profile
    {
        public UpdateProductReponseMapper()
        {
        }
    }
}
