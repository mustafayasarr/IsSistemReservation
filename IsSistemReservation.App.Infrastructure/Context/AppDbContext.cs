using IsSistemReservation.App.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsSistemReservation.App.Infrastructure.Context
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions options) : base(options)
		{
			AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

		}
		public DbSet<Reservation> Reservation { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Table> Table { get; set; }	
        public DbSet<TableCategory> TableCategory { get; set; }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Reservation>().HasQueryFilter(b => !b.IsDeleted);
			modelBuilder.Entity<Customer>().HasQueryFilter(b => !b.IsDeleted);
			modelBuilder.Entity<Table>().HasQueryFilter(b => !b.IsDeleted);
			modelBuilder.Entity<TableCategory>().HasQueryFilter(b => !b.IsDeleted);
			base.OnModelCreating(modelBuilder);

		}
		public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
		{
			foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
			{
				switch (entry.State)
				{
					case EntityState.Added:
						{
							if (entry.Entity.CreatedDate == DateTime.MinValue)
							{
								entry.Entity.CreatedDate = DateTime.Now;
								entry.Entity.IsActive = true;
								entry.Entity.IsDeleted = false;
							}
							break;
						}

					case EntityState.Modified:
						{
							if (entry.Entity.ModifiedDate == null)
							{
								entry.Entity.ModifiedDate = DateTime.Now;
							}
							break;
						}
					case EntityState.Deleted:
						{
							entry.State = EntityState.Modified;
							entry.Entity.IsDeleted = true;
							if (entry.Entity.ModifiedDate == null)
							{
								entry.Entity.ModifiedDate = DateTime.Now;
							}
							break;
						}

				}
			}
			return base.SaveChangesAsync(cancellationToken);

		}
	}
}
