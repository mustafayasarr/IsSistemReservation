using IsSistemReservation.App.Infrastructure.Context;
using IsSistemReservation.App.Infrastructure.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IsSistemReservation.App.Infrastructure.Repositories.Concrete
{
	public abstract class Repository<T> : IRepository<T> where T : class
	{
		private readonly AppDbContext _dbContext;

		public Repository(AppDbContext dbContext)
		{
			_dbContext = dbContext;
			Table = dbContext.Set<T>();
		}
		public DbSet<T> Table { get; set; }

		public void Add(T entity)
		{
			Table.Add(entity);
		}

		public void AddRange(IEnumerable<T> entity)
		{
			Table.AddRange(entity);
		}

		public IQueryable<T> All()
		{
			return Table;
		}

		public async Task<int> CreateAsync(T entity)
		{
			await Table.AddAsync(entity);

			return await SaveAsync();
		}

		public async Task<int> CreateRangeAsync(IEnumerable<T> entity)
		{
			await Table.AddRangeAsync(entity);

			return await SaveAsync();
		}

		public async void Delete(T entity)
		{
			Table.Remove(entity);
		}

		public async void DeleteRange(IEnumerable<T> entities)
		{
			Table.RemoveRange(entities);
		}

		public async Task<bool> ExistsAsync(Expression<Func<T, bool>> where)
		{
			return await Table.AnyAsync(where);
		}

		public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> where)
		{


			return await Table.FirstOrDefaultAsync(where);
		}

		public async Task<T> FirstOrDefaultAsync()
		{
			return await Table.FirstOrDefaultAsync();
		}

		public IQueryable<T> OrderBy<TKey>(Expression<Func<T, TKey>> orderBy, bool isDesc)
		{

			if (isDesc)
			{
				return Table.OrderByDescending(orderBy);
			}

			return Table.OrderBy(orderBy);
		}

		public async Task<int> SaveAsync()
		{
			try
			{
				return await _dbContext.SaveChangesAsync();
			}
			catch (Exception)
			{
				throw;
			}
		}

		public async Task<List<T>> ToListAsync(Expression<Func<T, bool>> where)
		{
			return await Table.Where(where).ToListAsync();
		}

		public async Task<List<T>> ToListAsync()
		{
			return await Table.ToListAsync();
		}

		public void Update(T entity)
		{
			Table.Update(entity);
		}

		public async Task<int> UpdateAsync(T entity)
		{
			Table.Update(entity);

			return await SaveAsync();
		}

		public void UpdateRange(IEnumerable<T> entity)
		{
			Table.UpdateRange(entity);
		}

		public async Task<int> UpdateRangeAsync(IEnumerable<T> entity)
		{
			Table.UpdateRange(entity);

			return await SaveAsync();
		}

		public IQueryable<T> Where(Expression<Func<T, bool>> where)
		{
			return Table.Where(where);
		}
	}
}
