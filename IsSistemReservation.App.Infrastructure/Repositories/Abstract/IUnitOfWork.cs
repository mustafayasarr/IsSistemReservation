using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsSistemReservation.App.Infrastructure.Repositories.Abstract
{
	public interface IUnitOfWork : IDisposable
	{
		IReservationRepository BookingRepository { get; }
		ICustomerRepository CustomerRepository { get; }
		ITableRepository TableRepository { get; }
		ITableCategoryRepository TableCategoryRepository { get; }
		void Complete(bool state = true);
		Task CompleteAsync(bool state = true);
	}
}
