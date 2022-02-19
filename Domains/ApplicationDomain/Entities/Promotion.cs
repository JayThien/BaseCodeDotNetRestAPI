using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDomain.Entities
{
    public class Promotion : EntityBase<int>
    {
        public string Code { set; get; }
        public string Description { set; get; }
        public DateTime From { set; get; }
        public DateTime To { set; get; }
        public double MaximumDiscount { set; get; }
        public double MinimumOrderPrice { set; get; }
        public double DiscountPrice { set; get; }
        public bool IsPercent { set; get; }

        public int MinPoint { set; get; }
        public int MaxPoint { set; get; }
        public string ImageUrl { set; get; }
        public int AreaId { set; get; }
        public Area Area { set; get; }
    }
}
