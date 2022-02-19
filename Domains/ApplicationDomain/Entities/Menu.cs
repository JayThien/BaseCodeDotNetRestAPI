using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDomain.Entities
{
    public class Menu : EntityBase<int>
    {
        public int AreaId { set; get; }
        public Area Area { set; get; }
    }
}

