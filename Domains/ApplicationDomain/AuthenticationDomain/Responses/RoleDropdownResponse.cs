using ApplicationDomain.AuthenticationDomain.Bindings;
using ApplicationDomain.Common;
using System.Collections.Generic;

namespace ApplicationDomain.AuthenticationDomain.Responses
{
    public class RoleDropdownResponse : ResponseBase
    {
        public IEnumerable<RoleDropdownBinding> Data { set; get; }
    }


}
