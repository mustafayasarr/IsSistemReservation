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
		}
		public DbSet<Reservation> Booking { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Table> RestaurantTable { get; set; }	
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
							if (entry.Entity.CreatedAtUTC == DateTime.MinValue)
							{
								entry.Entity.CreatedAtUTC = DateTime.UtcNow;
								entry.Entity.IsDeleted = false;
							}
							break;
						}

					case EntityState.Modified:
						{
							if (entry.Entity.ModifiedAtUTC == null)
							{
								entry.Entity.ModifiedAtUTC = DateTime.UtcNow;
							}
							break;
						}
					case EntityState.Deleted:
						{
							entry.State = EntityState.Modified;
							entry.Entity.IsDeleted = true;
							if (entry.Entity.ModifiedAtUTC == null)
							{
								entry.Entity.ModifiedAtUTC = DateTime.UtcNow;
							}
							break;
						}

				}
			}
			return base.SaveChangesAsync(cancellationToken);

		}
	}
}
