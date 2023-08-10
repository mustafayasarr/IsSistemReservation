using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsSistemReservation.App.Domain.Models.Entities
{
	public class Table : EntityBase<Guid>
	{
        public Table(string tableName,int number,int capacity,Guid tableCategoryId)
        {
            TableName = tableName;
            Number = number;
            Capacity = capacity;
            TableCategoryId = tableCategoryId;
        }
        public Table()
        {
            
        }
        public string TableName { get; set; }
        public int Number { get; set; }
        public int Capacity { get; set; }
        public Guid TableCategoryId { get; set; }
        public IList<Reservation> Reservations { get; set; }
        public TableCategory TableCategory { get; set; }
    }
}
