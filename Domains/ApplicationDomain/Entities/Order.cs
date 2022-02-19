using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDomain.Entities
{
    public class Order : EntityBase<int>
    {
        public string Code { set; get; }
        public DateTime ShippingDate { set; get; }
        public string ShippingAddress { set; get; }
        public string BillingAddress { set; get; }
        public double ShippingFee { set; get; }
        public double ServiceFee { set; get; }
        public PaymentMethod PaymentMethod { set; get; }
        public string Note { set; get; }
        public string Receiver { set; get; }
        public string ReceiverPhone { set; get; }
        public string ReceiverEmail { set; get; }
        public int? PromotionId { set; get; }
        public Promotion Promotion { set; get; }
    }
}
