using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsSistemReservation.Notification.Domain.Models.Dtos
{
	public class ReservationResultDto
	{
		public ReservationResultDto(DateTime reservationDate, int numberofGuests, CustomerResultDto customer, TableResultDto table)
		{
			ReservationDate = reservationDate;
			NumberOfGuests = numberofGuests;
			Customer = customer;
			Table = table;
		}
		public ReservationResultDto()
		{

		}
		public DateTime ReservationDate { get; set; }
		public int NumberOfGuests { get; set; }
		public CustomerResultDto Customer { get; set; }
		public TableResultDto Table { get; set; }

	}
}
