using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDomain.Entities
{
    public class Area : EntityBase<int>
    {
        public string Name { set; get; }
        public string Code { set; get; }
        public Country Country { set; get; }

        public int? UserId { set; get; }
        public User User { set; get; }
    }

}
