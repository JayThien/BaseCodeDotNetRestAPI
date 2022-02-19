using ApplicationDomain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDomain.PromotionDomain.Requests
{
    public class ListPromotionRequest : PaginationRequest
    {
        public string Code { set; get; }
    }
}
