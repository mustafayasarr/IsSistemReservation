using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsSistemReservation.App.Domain.Models.Dtos.Customer
{
	public class CustomerResultDto
	{
        public CustomerResultDto(Guid id,string name,string lastName,string telNo,string email)
        {
			Id = id;
			Name = name;
			LastName = lastName;
			TelNo = telNo;
			Email = email;
        }
        public CustomerResultDto()
        {
            
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
		public string LastName { get; set; }
		public string TelNo { get; set; }
		public string Email { get; set; }
	}
}
