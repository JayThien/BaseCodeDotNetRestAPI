using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDomain.Entities
{
    public class OrderPromotion : EntityBase<int>
    {
        public int OrderId { set; get; }
        public Order Order { set; get; }
        public int PromotionId { set; get; }
        public Promotion Promotion { set; get; }
        public double Discount { set; get; }
    }
}
