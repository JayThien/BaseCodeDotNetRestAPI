using ApplicationDomain.Common;
using ApplicationDomain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDomain.ReferenceData.MenuRef.Responses
{
    public class CreateMenuResponse : ResponseBase
    {
        public int Id { set; get; }
    }

    public class CreateMenuReponseMapper : Profile
    {
        public CreateMenuReponseMapper()
        {
            CreateMap<Menu, CreateMenuResponse>();
        }
    }
}
