using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsSistemReservation.Notification.Domain.Models.Dtos
{
	public class TableResultDto
	{
		public TableResultDto(string tableName, int number, int capacity, DateTime createDate)
		{
			TableName = tableName;
			Number = number;
			Capacity = capacity;
			CreateDate = createDate;

		}
		public TableResultDto()
		{

		}
		public string TableName { get; set; }
		public int Number { get; set; }
		public int Capacity { get; set; }
		public DateTime CreateDate { get; set; }
	}
}
