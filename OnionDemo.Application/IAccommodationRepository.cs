using OnionDemo.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionDemo.Application
{
    public interface IAccommodationRepository
    {
        Accommodation GetAccommodation(int id);
        void AddAccommodation(Accommodation accommodation);
        void UpdateAccommodation(Accommodation accommodation, byte[] rowversion);
        void DeleteAccommodation(Accommodation accommodation, byte[] rowversion);
        Booking GetBooking(int id);
        void AddBooking(Booking booking);
        void UpdateBooking(Booking booking, byte[] rowversion);
        void DeleteBooking(Booking booking, byte[] rowversion);
    }
}
