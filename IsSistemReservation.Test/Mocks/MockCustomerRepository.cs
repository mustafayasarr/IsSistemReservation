using IsSistemReservation.App.Domain.Models.Entities;
using IsSistemReservation.App.Infrastructure.Repositories.Abstract;
using IsSistemReservation.App.Infrastructure.Repositories.Concrete;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IsSistemReservation.Test.Mocks
{
	public static class MockCustomerRepository
	{
		public static Mock<ICustomerRepository> GetCustomers()
		{
			var customers = new List<Customer>();
			customers.Add(new Customer()
			{
				Id = new Guid("fe0821fb-bd09-41d9-98ef-356778c35734"),
				Email = "mustafa@mustafayasar.info",
				Name = "Mustafa",
				LastName = "Yaşar",
				TelNo = "05314242875",
				CreatedDate = DateTime.Now,
				IsActive = true,
				IsDeleted = false
			});


			var mock = customers.AsQueryable().BuildMockDbSet();
			var mockRepo = new Mock<ICustomerRepository>();
			mockRepo.Setup(r => r.Table).Returns(mock.Object);
			mockRepo.Setup(r => r.FirstOrDefaultAsync()).ReturnsAsync(() =>customers.FirstOrDefault());
			mockRepo.Setup(r => r.Add(It.IsAny<Customer>()));
			return mockRepo;
		}
	}
}
