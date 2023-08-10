using IsSistemReservation.App.Domain.Models.Dtos.TableCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsSistemReservation.App.Domain.Models.Dtos.Table
{
	public class TableResultDto
	{
        public TableResultDto(string tableName,int number,int capacity,TableCategoryResultDto dto,DateTime createDate)
        {
			TableName = tableName;
			Number = number;
			Capacity = capacity;
			TableCategory = dto;
            CreateDate = createDate;
            
        }
        public TableResultDto()
        {
            
        }
        public string TableName { get; set; }
		public int Number { get; set; }
		public int Capacity { get; set; }
        public DateTime CreateDate { get; set; }
        public TableCategoryResultDto TableCategory { get; set; }
	}
}
