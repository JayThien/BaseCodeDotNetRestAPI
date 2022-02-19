using ApplicationDomain.AuthenticationDomain.Bindings;
using ApplicationDomain.Common;
using System.Collections.Generic;

namespace ApplicationDomain.AuthenticationDomain.Responses
{
    public class UserDropdownResponse : ResponseBase
    {
        public IEnumerable<UserDropdownBinding> Data { set; get; }
    }


}
