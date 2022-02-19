using ApplicationDomain.Common;
using ApplicationDomain.ReferenceData.RestaurantRef.Bindings;
using System.Collections.Generic;

namespace ApplicationDomain.ReferenceData.RestaurantRef.Responses
{
    public class RestaurantDropdownResponse : ResponseBase
    {
        public List<RestaurantDropdownBinding> Data { set; get; }
    }
}
