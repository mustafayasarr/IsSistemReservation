using Castle.Core.Resource;
using IsSistemReservation.App.Domain.Models.Entities;
using IsSistemReservation.App.Infrastructure.Repositories.Abstract;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsSistemReservation.Test.Mocks
{
	public static class MockReservationRepository
	{
		public static Mock<IReservationRepository> GetReservations()
		{
			var reservations = new List<Reservation>();
			reservations.Add(new Reservation()
			{
				Id = new Guid("f9233b3a-c68b-402a-a05d-acab0fd15f68"),
				CustomerId = new Guid("fe0821fb-bd09-41d9-98ef-356778c35734"),
				NumberOfGuests = 2,
				ReservationDate = DateTime.Now.Date,
				TableId = new Guid("d2920cc1-bfff-4d48-a983-9df14c51d779"),
				CreatedDate = DateTime.Now,
				IsActive = true,
				IsDeleted = false
			});
			var mock = reservations.AsQueryable().BuildMockDbSet();
			var mockRepo = new Mock<IReservationRepository>();
			mockRepo.Setup(r => r.Table).Returns(mock.Object);
			mockRepo.Setup(r => r.Add(It.IsAny<Reservation>()));
			return mockRepo;

		}
	}
}
