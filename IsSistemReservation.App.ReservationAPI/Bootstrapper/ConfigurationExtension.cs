using IsSistemReservation.App.Infrastructure.Context;
using IsSistemReservation.App.Infrastructure.Repositories.Abstract;
using IsSistemReservation.App.Infrastructure.Repositories.Concrete;
using Microsoft.EntityFrameworkCore;

namespace IsSistemReservation.App.ReservationAPI.Bootstrapper
{
	public static class ConfigurationExtension
	{
		public static IServiceCollection RegisterConfigurationServices(this IServiceCollection services, IConfiguration Configuration)
		{
			services.AddDbContext<AppDbContext>(options =>
					options.UseNpgsql(Configuration.GetConnectionString("DevelopmentDbConnection")));

			#region Lifetime

			services.AddScoped<IReservationRepository, ReservationRepository>();
			services.AddScoped<ICustomerRepository, CustomerRepository>();
			services.AddScoped<IRestaurantTableRepository, RestaurantTableRepository>();
			services.AddScoped<ITableCategoryRepository, TableCategoryRepository>();

			services.AddScoped<IUnitOfWork, UnitOfWork>();
			services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

			#endregion

			return services;
		}
	}
}
