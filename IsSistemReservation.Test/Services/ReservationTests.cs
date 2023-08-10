using Bogus;
using IsSistemReservation.App.Core.Gateways;
using IsSistemReservation.App.Core.Gateways.NotificationService;
using IsSistemReservation.App.Core.Services.Reservation;
using IsSistemReservation.App.Domain.Models.Dtos.Reservation;
using IsSistemReservation.App.Infrastructure.Repositories.Abstract;
using IsSistemReservation.Test.Mocks;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;
using Shouldly;


namespace IsSistemReservation.Test.Services
{
    public class ReservationTests:BaseTests
    {
        private ReservationRequestDto _reservation;
        private ReservationService _service;
        public ReservationTests()
        {
            var restService = new Mock<IRestService>();
            var notification = new Mock<INotificationGateway>();
            var logger = new Mock<ILogger<ReservationService>>();

            _service = new ReservationService(_mockUow.Object, notification.Object, logger.Object);

            var data = new Faker<ReservationRequestDto>()
                .RuleFor(a => a.CustomerId, new Guid("fe0821fb-bd09-41d9-98ef-356778c35734"))
                .RuleFor(a => a.NumberOfGuests, f => f.Random.Int(1, 4))
                .RuleFor(a => a.ReservationDate, f => f.Date.Recent(5));
            _reservation = data.Generate();

        }

        [Fact]
        public async Task CreateReservationTest()
        {
            var result = await _service.CreateReservation(_reservation);
            result.HasError.ShouldNotBe(true);

        }
    }
}
