using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsSistemReservation.App.Domain.Models.Entities
{
	public class Reservation : EntityBase<Guid>
	{
        public Guid CustomerId { get; set; }
		public Guid TableId { get; set; }
		public DateTime ReservationDate { get; set; }
		public int NumberOfGuests { get; set; }
        public Table Table { get; set; }
        public Customer Customer { get; set; }
    }
}
