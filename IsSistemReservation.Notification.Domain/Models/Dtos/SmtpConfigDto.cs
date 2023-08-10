using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsSistemReservation.Notification.Domain.Models.Dtos
{
	public class SmtpConfigDto
	{
		public string Host { get; set; }
		public string Port { get; set; }
		public string User { get; set; }
		public string Password { get; set; }
		public string UseSsl { get; set; }
	}
}
