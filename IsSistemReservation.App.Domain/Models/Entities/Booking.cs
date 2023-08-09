using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsSistemReservation.App.Domain.Models.Entities
{
	public class Booking : EntityBase<Guid>
	{
        public Guid CustomerId { get; set; }
		public Guid RestaurantTableId { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		public int PersonCount { get; set; }
		public int BabyCount { get; set; }
	}
}
