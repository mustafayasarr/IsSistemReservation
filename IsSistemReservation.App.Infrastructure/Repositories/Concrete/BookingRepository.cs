using IsSistemReservation.App.Domain.Models.Entities;
using IsSistemReservation.App.Infrastructure.Context;
using IsSistemReservation.App.Infrastructure.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsSistemReservation.App.Infrastructure.Repositories.Concrete
{
	public class BookingRepository : Repository<Booking>, IBookingRepository
	{
		public BookingRepository(AppDbContext dbContext) : base(dbContext)
		{
		}
	}
}
