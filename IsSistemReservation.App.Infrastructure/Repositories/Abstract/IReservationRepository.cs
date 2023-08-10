using IsSistemReservation.App.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsSistemReservation.App.Infrastructure.Repositories.Abstract
{
	public interface IReservationRepository:IRepository<Reservation>
	{
	}
}
