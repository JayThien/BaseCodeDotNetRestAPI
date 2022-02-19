using ApplicationDomain.BookingDomain.Requests;
using ApplicationDomain.Entities;
using ApplicationDomain.ReferenceData.RestaurantRef;
using AspNetCore.EmailSender;
using AspNetCore.UnitOfWork;
using AutoMapper;
using System;
using System.IO;
using System.Threading.Tasks;

namespace ApplicationDomain.BookingDomain
{
    public class BookingService : ServiceBase, IBookingService
    {
        private readonly IBookingRepository bookingRepository;
        private readonly IEmailSender emailSender;
        private readonly IRestaurantService restaurantService;
        public BookingService(
            IMapper mapper,
            IUnitOfWork uow,
            IBookingRepository bookingRepository,
            IEmailSender emailSender,
            IRestaurantService restaurantService
        ) : base(mapper, uow)
        {
            this.bookingRepository = bookingRepository;
            this.emailSender = emailSender;
            this.restaurantService = restaurantService;
        }

        public async Task Book(BookingRequest requestData)
        {
            var booking = new Booking();
            this._mapper.Map(requestData, booking);
            this.bookingRepository.Create(booking);
            await this._uow.SaveChangesAsync();

            string emailTemplate = System.IO.File.ReadAllText($@"{Directory.GetCurrentDirectory()}\\bin\\Debug\net5.0\\EmailTemplate\\Booking.html");

            var restaurant = await this.restaurantService.GetByIdAsync(requestData.RestaurantId);

            emailTemplate = emailTemplate.Replace("{{restaurantName}}", restaurant.Name);
            emailTemplate = emailTemplate.Replace("{{restaurantAddress}}", restaurant.Address);
            emailTemplate = emailTemplate.Replace("{{restaurantPhone}}", restaurant.PhoneNumber);
            emailTemplate = emailTemplate.Replace("{{restaurantLocationImage}}", restaurant.LocationImage);

            emailTemplate = emailTemplate.Replace("{{bookingName}}", $"{requestData.FirstName} {requestData.LastName}");
            emailTemplate = emailTemplate.Replace("{{bookingPhone}}", requestData.Phone);
            emailTemplate = emailTemplate.Replace("{{bookingEmail}}", requestData.Email);

            emailTemplate = emailTemplate.Replace("{{eventType}}", Enum.GetName(typeof(EventType), requestData.EventType));
            emailTemplate = emailTemplate.Replace("{{partySize}}", requestData.Size.ToString());
            emailTemplate = emailTemplate.Replace("{{bookingDate}}", requestData.DateTime.ToString("dd/MM/yyyy hh:mm:ss"));
            emailTemplate = emailTemplate.Replace("{{message}}", requestData.Message);

            await this.emailSender.SendEmailAsync(requestData.Email, "Your Request for Private Dinning | Event", emailTemplate, true);
        }

    }
}
