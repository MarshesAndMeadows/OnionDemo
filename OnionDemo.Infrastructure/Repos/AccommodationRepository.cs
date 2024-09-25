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
    public class AccommodationRepository : IAccommodationRepository
    {
        private readonly BookMyHomeContext _db;

        public AccommodationRepository(BookMyHomeContext context)
        {
            _db = context;
        }

        void IAccommodationRepository.Add(Accommodation accommodation)
        {
            _db.Accommodations.Add(accommodation);
            _db.SaveChanges();
        }

        void IAccommodationRepository.AddBooking(Accommodation accommodation)
        {
            _db.SaveChanges();
        }


        Accommodation IAccommodationRepository.GetAccommodation(int id)
        {
            return _db.Accommodations.Include(a => a.Bookings).Single(a => a.Id == id);
        }

        void IAccommodationRepository.UpdateBooking(Booking booking, byte[] rowversion)
        {
            _db.Entry(booking).Property(nameof(booking.RowVersion)).OriginalValue = rowversion;
            _db.SaveChanges();
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
