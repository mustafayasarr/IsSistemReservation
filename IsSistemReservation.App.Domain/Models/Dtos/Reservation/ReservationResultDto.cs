using IsSistemReservation.App.Domain.Models.Dtos.Customer;
using IsSistemReservation.App.Domain.Models.Dtos.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsSistemReservation.App.Domain.Models.Dtos.Reservation
{
	public class ReservationResultDto
	{
        public ReservationResultDto(Guid id,DateTime reservationDate,int numberofGuests,CustomerResultDto customer,TableResultDto table)
        {
            Id = id;
            ReservationDate = reservationDate;
            NumberOfGuests = numberofGuests;
            Customer = customer;
            Table = table;
        }
        public ReservationResultDto()
        {
            
        }
        public Guid Id { get; set; }
		public DateTime ReservationDate { get; set; }
		public int NumberOfGuests { get; set; }
		public CustomerResultDto Customer{ get; set; }
        public TableResultDto Table { get; set; }
        
    }
}
