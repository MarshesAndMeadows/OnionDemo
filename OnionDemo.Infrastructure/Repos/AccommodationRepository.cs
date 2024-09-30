using OnionDemo.Application;
using OnionDemo.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace OnionDemo.Infrastructure.Repos
{
    public class AccommodationRepository(BookMyHomeContext context) : IAccommodationRepository
    {
        void IAccommodationRepository.Add(Accommodation accommodation)
        {
            context.Accommodations.Add(accommodation);
            context.SaveChanges();
        }
        void IAccommodationRepository.AddBooking(Accommodation accommodation)
        {
            context.SaveChanges();
        }
        Accommodation IAccommodationRepository.GetAccommodation(int id)
        {
            return context.Accommodations.Include(a => a.Bookings).Single(a => a.Id == id);
        }
        void IAccommodationRepository.UpdateBooking(Booking booking, byte[] rowversion)
        {
            context.Entry(booking).Property(nameof(booking.RowVersion)).OriginalValue = rowversion;
            context.SaveChanges();
        }

        Booking IAccommodationRepository.GetBooking(int id)
        {
            return context.Bookings.Where(a => a.Id == id).Single();
        }
        /*
                void IAccommodationRepository.Update(Accommodation accommodation, byte[] rowVersion)
                {
                    _db.Entry(accommodation).Property(nameof(Accommodation.RowVersion)).OriginalValue = rowVersion;
                    _db.Accommodations.Update(accommodation);
                    _db.SaveChanges();
                }
                void IAccommodationRepository.Delete(Accommodation accommodation, byte[] rowVersion)
                {
                    _db.Entry(accommodation).Property(nameof(Accommodation.RowVersion)).OriginalValue = rowVersion;
                    _db.Accommodations.Remove(accommodation);
                    _db.SaveChanges();
                }*/
    }
}
