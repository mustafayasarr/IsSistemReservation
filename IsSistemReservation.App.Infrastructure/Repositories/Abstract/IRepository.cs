using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IsSistemReservation.App.Infrastructure.Repositories.Abstract
{
	public interface IRepository<T> where T : class
	{
		DbSet<T> Table { get; }

		void Add(T entity);
		void AddRange(IEnumerable<T> entity);
		void Update(T entity);

		Task<int> CreateAsync(T entity);

		Task<int> UpdateAsync(T entity);

		Task<int> UpdateRangeAsync(IEnumerable<T> entity);

		void UpdateRange(IEnumerable<T> entity);

		void Delete(T entity);

		void DeleteRange(IEnumerable<T> entities);

		Task<int> CreateRangeAsync(IEnumerable<T> entity);

		Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> where);
		Task<T> FirstOrDefaultAsync();

		Task<List<T>> ToListAsync(Expression<Func<T, bool>> where);
		Task<List<T>> ToListAsync();
		Task<bool> ExistsAsync(Expression<Func<T, bool>> where);

		IQueryable<T> All();

		IQueryable<T> Where(Expression<Func<T, bool>> where);

		IQueryable<T> OrderBy<TKey>(Expression<Func<T, TKey>> orderBy, bool isDesc);
		Task<int> SaveAsync();
	}
}
