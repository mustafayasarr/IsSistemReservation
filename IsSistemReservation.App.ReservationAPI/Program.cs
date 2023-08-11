using FluentValidation;
using IsSistemReservation.App.Domain.Models.Dtos;
using IsSistemReservation.App.Infrastructure.Context;
using IsSistemReservation.App.ReservationAPI.Bootstrapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Text.Json;
using FluentValidation.AspNetCore;
using IsSistemReservation.App.Core.Validator;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddValidatorsFromAssemblyContaining<Program>();

// Add services to the container.

builder.Services.AddControllers().ConfigureApiBehaviorOptions(options =>
{
	options.InvalidModelStateResponseFactory = context =>
	{
		var errors = context.ModelState.Values
			.SelectMany(v => v.Errors)
			.Select(e => JsonSerializer.Deserialize<Error>(e.ErrorMessage));
		return new BadRequestObjectResult(errors);
	};
}).AddFluentValidation(config =>
	 {
		 config.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
	 });
builder.Services.AddTransient<IValidatorInterceptor, UseCustomErrorModelInterceptor>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.RegisterConfigurationServices(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}
using (var scope = app.Services.CreateScope())
{
	var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
	db.Database.Migrate();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
