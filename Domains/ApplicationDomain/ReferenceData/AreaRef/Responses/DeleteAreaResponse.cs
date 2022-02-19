using ApplicationDomain.Common;
using ApplicationDomain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDomain.ReferenceData.AreaRef.Responses
{
    public class DeleteAreaResponse : ResponseBase
    {
        public int Id { set; get; }
    }

    public class DeleteAreaReponseMapper : Profile
    {
        public DeleteAreaReponseMapper()
        {
        }
    }
}
