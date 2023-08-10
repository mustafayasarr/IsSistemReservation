using Hangfire;
using Hangfire.Dashboard;
using Hangfire.PostgreSql;
using IsSistemReservation.Notification.Core.Services.Mail;
using IsSistemReservation.Notification.Domain.Models.Dtos;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IMailService, MailService>();
builder.Services.Configure<SmtpConfigDto>(builder.Configuration.GetSection("SmtpConfig"));

builder.Services.AddHangfire(config =>
	config.UsePostgreSqlStorage(builder.Configuration.GetConnectionString("DevelopmentDbConnection"))
);


var options = new DashboardOptions()
{
	Authorization = new[] { new MyAuthorizationFilter() }
};

var app = builder.Build();
app.UseHangfireDashboard("/hangfire",options);

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
GlobalJobFilters.Filters.Add(new AutomaticRetryAttribute { Attempts = 7 });

app.Run();
public class MyAuthorizationFilter : IDashboardAuthorizationFilter
{
	public bool Authorize(DashboardContext context) => true;
}