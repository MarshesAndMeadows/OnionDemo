using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using OnionDemo.Application;
using OnionDemo.Application.Command.CommandDTO;
using OnionDemo.Domain.Entity;
using System.Data;

namespace OnionDemo.Infrastructure.BookingInfrastructure;

public class BookingRepository(BookMyHomeContext context) : IBookingRepository
{
    void IBookingRepository.AddBooking(Booking booking)
    {
        context.Bookings.Add(booking);
        context.SaveChanges();
    }
    Booking IBookingRepository.GetBooking(int id)
    {
        return context.Bookings.Single(a => a.Id == id);
    }
    void IBookingRepository.UpdateBooking(Booking booking, byte[] rowVersion)
    {
        context.Entry(booking).Property(nameof(Booking.RowVersion)).OriginalValue = rowVersion;
        context.Bookings.Update(booking);
        context.SaveChanges();
    }
    void IBookingRepository.DeleteBooking(Booking booking, byte[] rowVersion)
    {
        context.Entry(booking).Property(nameof(Booking.RowVersion)).OriginalValue = rowVersion;
        context.Bookings.Remove(booking);
        context.SaveChanges();
    }
}
