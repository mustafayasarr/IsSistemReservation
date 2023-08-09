using IsSistemReservation.App.Infrastructure.Context;
using IsSistemReservation.App.Infrastructure.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsSistemReservation.App.Infrastructure.Repositories.Concrete
{
	public class UnitOfWork : IUnitOfWork
	{
		IDbContextTransaction transaction = null;
		AppDbContext _context;

		public UnitOfWork(AppDbContext context)
		{
			_context = context;
			transaction = context.Database.BeginTransaction();
			BookingRepository=new BookingRepository(_context);
			CustomerRepository=new CustomerRepository(_context);
			RestaurantTableRepository=new RestaurantTableRepository(_context);
			TableCategoryRepository=new TableCategoryRepository(_context);
		}

		public IBookingRepository BookingRepository { get; }

		public ICustomerRepository CustomerRepository { get; }

		public IRestaurantTableRepository RestaurantTableRepository { get; }

		public ITableCategoryRepository TableCategoryRepository { get; }

		public void Complete(bool state = true)
		{
			_context.SaveChanges();
			if (state)
			{
				transaction.Commit();
			}
			else
			{
				transaction.Rollback();
			}
			Dispose();
		}

		public async Task CompleteAsync(bool state = true)
		{
			await _context.SaveChangesAsync();
			if (state)
			{
				transaction.Commit();
			}
			else
			{
				transaction.Rollback();
			}
			Dispose();
		}

		public void Dispose()
		{
			_context.Dispose();
		}

		
	}
}
