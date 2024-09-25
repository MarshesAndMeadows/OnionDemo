using OnionDemo.Application.Commands.CommandDTO.Accommodation;
using OnionDemo.Application.Commands.CommandDTO.Booking;

namespace OnionDemo.Application.Commands
{
    public interface IAccommodationCommand
    {
        void Create(CreateAccommodationDto createAccommodationDto);
        void Update(UpdateAccommodationDto updateAccommodationDto);
        void Delete(DeleteAccommodationDto deleteAccommodationDto);
        void CreateBooking(CreateBookingDto createBookingDto);
        void UpdateBooking(UpdateBookingDto updateBookingDto);
        void DeleteBooking(DeleteBookingDto deleteBookingDto);
    }
}

