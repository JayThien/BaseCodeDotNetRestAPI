using ApplicationDomain.Common;
using ApplicationDomain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDomain.ReferenceData.MenuRef.Responses
{
    public class DeleteMenuResponse : ResponseBase
    {
        public int Id { set; get; }
    }

    public class DeleteMenuReponseMapper : Profile
    {
        public DeleteMenuReponseMapper()
        {
        }
    }
}
