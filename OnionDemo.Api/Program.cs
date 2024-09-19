using Microsoft.AspNetCore.Mvc;
using OnionDemo.Application;
using OnionDemo.Application.AccommodationCommand;
using OnionDemo.Application.Commands.AccommodationCommand;
using OnionDemo.Application.Commands.AccommodationCommand.CommandDTO;
using OnionDemo.Application.Queries.BookingQuery;
using OnionDemo.Application.Queries.HostQuery;
using OnionDemo.Infrastructure;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Application and Infrastructure services
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// https://learn.microsoft.com/en-us/aspnet/core/tutorials/min-web-api?view=aspnetcore-8.0&tabs=visual-studio
app.MapGet("/hello", () => "Hello World");


app.MapGet("/booking", (IBookingQuery query) => query.GetBookings());
app.MapGet("/booking/{id}", (int id, IBookingQuery query) => query.GetBooking(id));
//app.MapPost("/booking", ([FromBody] CreateBookingDto booking, IAccommodationCommand command) => command.CreateBooking(booking));
//app.MapPut("/booking", ([FromBody] UpdateBookingDto booking, IAccommodationCommand command) => command.UpdateBooking(booking));

app.MapGet("/host/id", (int id, IHostQuery query) => query.GetAccommodations(id));

app.Run();