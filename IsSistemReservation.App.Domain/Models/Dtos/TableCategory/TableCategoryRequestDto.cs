using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsSistemReservation.App.Domain.Models.Dtos.TableCategory
{
	public class TableCategoryRequestDto
	{
		public TableCategoryRequestDto(string code, string environmentName)
		{
			Code = code;
			EnvironmentName = environmentName;
		}

		public string Code { get; set; }
		public string EnvironmentName { get; set; }
	}
}
