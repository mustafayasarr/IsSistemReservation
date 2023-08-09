using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsSistemReservation.App.Domain.Models.Entities
{
	public class RestaurantTable : EntityBase<Guid>
	{
        public RestaurantTable()
        {
            
        }
        public string TableName { get; set; }
        public string TableNo { get; set; }
        public int ChairsCount { get; set; }
        public int BabyHighchairsCount { get; set; }
        public Guid TableCategory { get; set; }
        public IList<Booking> Bookings { get; set; }
    }
}
