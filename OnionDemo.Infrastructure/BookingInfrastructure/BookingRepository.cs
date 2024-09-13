using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using OnionDemo.Application;
using OnionDemo.Application.Command.CommandDTO;
using OnionDemo.Domain.Entity;
using System.Data;

namespace OnionDemo.Infrastructure.BookingInfrastructure;

public class BookingRepository(BookMyHomeContext db) : IBookingRepository
{
    void IBookingRepository.AddBooking(Booking booking)
    {
        db.Bookings.Add(booking);
        db.SaveChanges();
    }
    Booking IBookingRepository.GetBooking(int id)
    {
        return db.Bookings.Single(a => a.Id == id);
    }
    void IBookingRepository.UpdateBooking(Booking booking, byte[] rowVersion)
    {
        db.Entry(booking).Property(nameof(Booking.RowVersion)).OriginalValue = rowVersion;
        db.Bookings.Update(booking);
        db.SaveChanges();
    }
    void IBookingRepository.DeleteBooking(Booking booking, byte[] rowVersion)
    {
        db.Entry(booking).Property(nameof(Booking.RowVersion)).OriginalValue = rowVersion;
        db.Bookings.Remove(booking);
        db.SaveChanges();
    }
}
