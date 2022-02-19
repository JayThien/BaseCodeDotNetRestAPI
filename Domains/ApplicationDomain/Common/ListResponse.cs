using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDomain.Common
{
    public class ListResponse<T>
    {
        public IEnumerable<T> Data { set; get; }
    }
}
