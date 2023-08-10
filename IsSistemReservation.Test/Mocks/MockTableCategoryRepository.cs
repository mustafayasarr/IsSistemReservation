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
	public static class MockTableCategoryRepository
	{
		public static Mock<ITableCategoryRepository> GetTableCategories()
		{
			var tableCategories = new List<TableCategory>();
			tableCategories.Add(new TableCategory()
			{
				Id = new Guid("b3de6bf4-f285-45a8-9cb6-73cdfc10a183"),
				Code = "B",
				CreatedDate = DateTime.Now,
				EnvironmentName = "BALKON",
				IsActive = true,
				IsDeleted = false
			});
			tableCategories.Add(new TableCategory()
			{
				Id = new Guid("19914837-ce81-430b-9ff9-1794ad6a5ede"),
				Code = "S",
				CreatedDate = DateTime.Now,
				EnvironmentName = "SALON",
				IsActive = true,
				IsDeleted = false
			});

			var mock = tableCategories.AsQueryable().BuildMockDbSet();
			var mockRepo = new Mock<ITableCategoryRepository>();
			mockRepo.Setup(r => r.Table).Returns(mock.Object);
			mockRepo.Setup(r => r.Add(It.IsAny<TableCategory>()));
			return mockRepo;

		}
	}
}
