using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsSistemReservation.App.Domain.Models.Entities
{
	public class TableCategory : EntityBase<Guid>
	{
        public TableCategory(string code,string environmentName)
        {
            Code = code;
            EnvironmentName=environmentName;
        }
        public TableCategory()
        {
            
        }
        public string Code { get; set; }
        public string EnvironmentName { get; set; }
		public IList<RestaurantTable> ContactInfo { get; set; }
	}
}
