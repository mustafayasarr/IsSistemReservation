using IsSistemReservation.App.Infrastructure.Repositories.Abstract;
using IsSistemReservation.Test.Mocks;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsSistemReservation.Test.Services
{
	public class BaseTests
	{
		public readonly Mock<IUnitOfWork> _mockUow;
        public BaseTests()
        {
			_mockUow = MockUnitOfWork.GetUnitOfWork();

		}
	}
}
