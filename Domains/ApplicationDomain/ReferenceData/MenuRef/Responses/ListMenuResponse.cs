using ApplicationDomain.Common;
using ApplicationDomain.Entities;
using ApplicationDomain.ReferenceData.MenuRef.Bindings;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDomain.ReferenceData.MenuRef.Responses
{
    public class ListMenuResponse : ResponseBase
    {
        public IEnumerable<ListMenuBinding> Data { set; get; }
    }

}
