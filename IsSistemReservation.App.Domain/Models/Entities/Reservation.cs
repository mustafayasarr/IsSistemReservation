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
		public Guid RestaurantTableId { get; set; }
		public DateTime ReservationDate { get; set; }
		public int NumberOfGuests { get; set; }
	}
}
