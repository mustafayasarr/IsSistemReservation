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
	public static class MockTableRepository
	{
		public static Mock<ITableRepository> GetTables()
		{
			var tableCategories = new List<Table>();
			tableCategories.Add(new Table()
			{
				Id = new Guid("d2920cc1-bfff-4d48-a983-9df14c51d779"),
				Capacity=2,
				Number=1,
				TableCategoryId=new Guid("b3de6bf4-f285-45a8-9cb6-73cdfc10a183"),
				TableName="BALKON MASASI",
				CreatedDate = DateTime.Now,
				IsActive = true,
				IsDeleted = false
			});

			tableCategories.Add(new Table()
			{
				Id = new Guid("b93da75e-fd78-4e09-a373-7bdf3b052b6b"),
				Capacity = 4,
				Number = 2,
				TableCategoryId = new Guid("b3de6bf4-f285-45a8-9cb6-73cdfc10a183"),
				TableName = "BALKON MASASI",
				CreatedDate = DateTime.Now,
				IsActive = true,
				IsDeleted = false
			});

			tableCategories.Add(new Table()
			{
				Id = new Guid("1f1e7f40-c6ee-4e76-afad-84f3ea0f7464"),
				Capacity = 4,
				Number = 1,
				TableCategoryId = new Guid("19914837-ce81-430b-9ff9-1794ad6a5ede"),
				TableName = "BALKON MASASI",
				CreatedDate = DateTime.Now,
				IsActive = true,
				IsDeleted = false
			});

			var mock = tableCategories.AsQueryable().BuildMockDbSet();
			var mockRepo = new Mock<ITableRepository>();
			mockRepo.Setup(r => r.Table).Returns(mock.Object);
			mockRepo.Setup(r => r.Add(It.IsAny<Table>()));
			return mockRepo;


		}

	}
}
