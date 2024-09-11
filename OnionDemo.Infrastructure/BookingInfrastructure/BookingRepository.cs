using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using OnionDemo.Application;
using OnionDemo.Application.Command.CommandDTO;
using OnionDemo.Domain.Entity;
using System.Data;

namespace OnionDemo.Infrastructure.BookingInfrastructure;

public class BookingRepository : IBookingRepository
{
    private readonly BookMyHomeContext _db;
    public BookingRepository(BookMyHomeContext context)
    {
        _db = context;
    }

    void IBookingRepository.AddBooking(Booking booking)
    {
        _db.Bookings.Add(booking);
        _db.SaveChanges();
    }
    Booking IBookingRepository.GetBooking(int id)
    {
        return _db.Bookings.Single(a => a.Id == id);
    }
    void IBookingRepository.UpdateBooking(Booking booking, byte[] rowVersion)
    {
        _db.Entry(booking).Property(nameof(Booking.RowVersion)).OriginalValue = rowVersion;
        _db.Bookings.Update(booking);
        _db.SaveChanges();
    }
    void IBookingRepository.DeleteBooking(Booking booking, byte[] rowVersion)
    {
        _db.Entry(booking).Property(nameof(Booking.RowVersion)).OriginalValue = rowVersion;
        _db.Bookings.Remove(booking);
        _db.SaveChanges();
    }
}
