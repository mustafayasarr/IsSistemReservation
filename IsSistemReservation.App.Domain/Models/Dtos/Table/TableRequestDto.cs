using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsSistemReservation.App.Domain.Models.Dtos.Table
{
	public class TableRequestDto
	{
        public TableRequestDto(string tableName,int number,int capacity,Guid tableCategoryId)
        {
			TableName = tableName;
			Number = number;
			Capacity = capacity;
			TableCategoryId = tableCategoryId;
            
        }
        public TableRequestDto()
        {
            
        }
        public string TableName { get; set; }
		public int Number { get; set; }
		public int Capacity { get; set; }
		public Guid TableCategoryId { get; set; }
	}
}
