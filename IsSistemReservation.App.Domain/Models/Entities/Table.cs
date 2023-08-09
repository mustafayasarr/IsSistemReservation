using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsSistemReservation.App.Domain.Models.Entities
{
	public class Table : EntityBase<Guid>
	{
        public Table()
        {
            
        }
        public string TableName { get; set; }
        public int Number { get; set; }
        public int Capacity { get; set; }
        public int BabyCapacity { get; set; }
        public Guid TableCategory { get; set; }
        public IList<Reservation> Bookings { get; set; }
    }
}
