using IsSistemReservation.App.Domain.Models.Dtos.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsSistemReservation.App.Domain.Models.Dtos.Reservation
{
	public class ReservationRequestDto
	{
        public Guid CustomerId { get; set; }
     
		public DateTime ReservationDate { get; set; }
		public int NumberOfGuests { get; set; }

	}
}
