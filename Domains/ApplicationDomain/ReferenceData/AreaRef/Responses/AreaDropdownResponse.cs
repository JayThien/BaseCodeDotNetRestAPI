using ApplicationDomain.Common;
using ApplicationDomain.ReferenceData.AreaRef.Bindings;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDomain.ReferenceData.AreaRef.Responses
{
    public class AreaDropdownResponse : ResponseBase
    {
        public IEnumerable<AreaDropdownBinding> Data { set; get; }
    }
}
