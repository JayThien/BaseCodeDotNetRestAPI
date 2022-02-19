using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDomain.Entities
{
    public class UserPromotion : EntityBase<int>
    {
        public int UserId { set; get; }
        public User User { set; get; }
        public int PromotionId { set; get; }
        public Promotion Promotion { set; get; }
        public bool IsApplied { set; get; }
    }
}
