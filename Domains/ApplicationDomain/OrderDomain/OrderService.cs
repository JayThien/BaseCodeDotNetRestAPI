using ApplicationDomain.Common;
using ApplicationDomain.Entities;
using ApplicationDomain.IRepositories;
using ApplicationDomain.IServices;
using ApplicationDomain.OrderDomain.Requests;
using ApplicationDomain.OrderDomain.Responses;
using AspNetCore.EmailSender;
using AspNetCore.UnitOfWork;
using AutoMapper;
using System;
using System.IO;
using System.Threading.Tasks;

namespace ApplicationDomain.Services
{
    public class OrderService : ServiceBase, IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderProductService _orderProductService;
        private readonly IEmailSender _emailSender;

        public OrderService(
            IMapper mapper,
            IUnitOfWork uow,
            IOrderRepository orderRepository,
            IOrderProductService orderProductService,
            IEmailSender emailSender
            ) : base(mapper, uow)
        {
            this._orderRepository = orderRepository;
            this._orderProductService = orderProductService;
            this._emailSender = emailSender;
        }

        public async Task<OrderResponse> Order(OrderRequest request)
        {
            var order = new Order();
            this._mapper.Map(request, order);
            this._orderRepository.Create(order);

            await this._uow.SaveChangesAsync();
            await this._orderProductService.AddProductToOrder(request.OrderProducts, order.Id);

            string emailTemplate = System.IO.File.ReadAllText($@"{Directory.GetCurrentDirectory()}\\bin\\Debug\net5.0\\EmailTemplate\\Order.html");

            emailTemplate = emailTemplate.Replace("{{itemCount}}", request.OrderProducts.Count == 1 ? $"{request.OrderProducts.Count} item" : $"{request.OrderProducts.Count} items");
            double subTotal = 0;
            string productsTemplate = "";
            foreach (var product in request.OrderProducts)
            {
                string productTemplate = "<tr style=\"border-collapse:collapse; border-bottom:0.5px solid #CCCCCC;\">" +
                     "<td style = \"padding:10px 10px 10px 0; margin:0\" width = \"80%\" align = \"left\" >" +
                     $"<p class=\"product\"><strong>{product.Name}</strong> x{product.Quantity}</p>" +
                     "{{additions}}" +
                     "</td>" +
                     "<td style = \"padding:0; margin:0\" width=\"20%\" align=\"right\">" +
                     $"<p class=\"product\">{StringUtil.ConvertToVND(product.TotalPriceOfProduct)}</p>" +
                     "</td>" +
                     "</tr>";
                subTotal += product.TotalPriceOfProduct;
                string additionItem = "";
                foreach (var addition in product.Additions)
                {
                    foreach (var item in addition.Items)
                    {
                        if (item.IsCheck)
                        {
                            additionItem += $"<p class=\"product\">{item.Name}</p>";
                        }
                    }
                }
                productTemplate = productTemplate.Replace("{{additions}}", additionItem);
                productsTemplate += productTemplate;
            }

            emailTemplate = emailTemplate.Replace("{{products}}", productsTemplate);

            emailTemplate = emailTemplate.Replace("{{receiverName}}", request.Receiver);
            emailTemplate = emailTemplate.Replace("{{receiverPhone}}", request.ReceiverPhone);
            emailTemplate = emailTemplate.Replace("{{shippingAddress}}", request.ShippingAddress);

            emailTemplate = emailTemplate.Replace("{{subTotal}}", StringUtil.ConvertToVND(subTotal));
            emailTemplate = emailTemplate.Replace("{{shipping}}", StringUtil.ConvertToVND(request.ShippingFee));
            emailTemplate = emailTemplate.Replace("{{serviceCharge}}", StringUtil.ConvertToVND(request.ServiceFee));
            emailTemplate = emailTemplate.Replace("{{paymentMethod}}", Enum.GetName(typeof(PaymentMethod), request.PaymentMethod));
            emailTemplate = emailTemplate.Replace("{{total}}", StringUtil.ConvertToVND(request.ShippingFee + request.ServiceFee + subTotal));
            emailTemplate = emailTemplate.Replace("{{note}}", request.Note ?? "...");

            emailTemplate = emailTemplate.Replace("{{itemCount}}", request.OrderProducts.Count == 1 ? $"{request.OrderProducts.Count} item" : $"{request.OrderProducts.Count} items");

            await this._emailSender.SendEmailAsync(request.ReceiverEmail, "Order", emailTemplate, true);

            return new OrderResponse() { Id = order.Id };
        }
    }
}