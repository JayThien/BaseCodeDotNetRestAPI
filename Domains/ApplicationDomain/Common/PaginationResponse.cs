using AspNetCore.DataBinding.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApplicationDomain.Common
{
    public abstract class PaginationResponse<T>: ResponseBase
    {
        public int PageNumber { set; get; }
        public int TotalRows { set; get; }
        public IEnumerable<T> Data { set; get; }
    }
}
