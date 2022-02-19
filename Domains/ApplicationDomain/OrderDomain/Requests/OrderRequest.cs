using ApplicationDomain.Common;
using ApplicationDomain.Entities;
using ApplicationDomain.OrderDomain.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDomain.OrderDomain.Requests
{
    public class OrderRequest : RequestBase
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
        public List<OrderProductDTO> OrderProducts { set; get; }
    }
    public class OrderRequestMapper : Profile
    {
        public OrderRequestMapper()
        {
            CreateMap<OrderRequest, Order>();
        }
    }
}
