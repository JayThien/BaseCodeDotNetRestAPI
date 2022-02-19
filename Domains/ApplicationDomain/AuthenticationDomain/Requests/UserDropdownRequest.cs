using ApplicationDomain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDomain.AuthenticationDomain.Requests
{
    public class UserDropdownRequest: RequestBase
    {
        public string SearchTerm { set; get; }
        public string RoleName { set; get; }
    }
}
