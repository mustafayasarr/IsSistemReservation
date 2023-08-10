using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsSistemReservation.Notification.Domain.Models.Dtos
{
	public class CustomerResultDto
	{
		public CustomerResultDto(string name, string lastName, string telNo, string email)
		{
			Name = name;
			LastName = lastName;
			TelNo = telNo;
			Email = email;
		}
		public CustomerResultDto()
		{

		}
		public string Name { get; set; }
		public string LastName { get; set; }
		public string TelNo { get; set; }
		public string Email { get; set; }
	}
}
