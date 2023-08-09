using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsSistemReservation.App.Domain.Models.Entities
{
	public class Customer : EntityBase<Guid>
	{
		public Customer(string name, string lastName, string telNo, string email)
		{
			Name = name;
			LastName = lastName;
			TelNo = telNo;
			Email = email;
			 
		}
        public Customer()
        {
            
        }

        public string Name { get; set; }
		public string LastName { get; set; }
		public string TelNo { get; set; }
		public string Email { get; set; }
		public IList<Reservation> Reservations { get; set; }

	}
}
