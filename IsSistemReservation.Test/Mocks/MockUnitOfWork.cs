using IsSistemReservation.App.Infrastructure.Repositories.Abstract;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsSistemReservation.Test.Mocks
{
	public class MockUnitOfWork
	{
		public static Mock<IUnitOfWork> GetUnitOfWork()
		{
			var mockUow = new Mock<IUnitOfWork>();
			var mockCustomerRepo = MockCustomerRepository.GetCustomers();
			var mockTableRepo = MockTableRepository.GetTables();
			var mockTableCategoryRepo = MockTableCategoryRepository.GetTableCategories();
			var mockReservationRepo = MockReservationRepository.GetReservations();

			mockUow.Setup(r => r.TableCategoryRepository).Returns(mockTableCategoryRepo.Object);
			mockUow.Setup(r => r.TableRepository).Returns(mockTableRepo.Object);
			mockUow.Setup(r => r.CustomerRepository).Returns(mockCustomerRepo.Object);
			mockUow.Setup(r => r.ReservationRepository).Returns(mockReservationRepo.Object);

			return mockUow;
		}
	}
}
