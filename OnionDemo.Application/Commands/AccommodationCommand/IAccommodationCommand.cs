using OnionDemo.Application.Commands.AccommodationCommand.CommandDTO;

namespace OnionDemo.Application.Commands.AccommodationCommand
{
    public interface IAccommodationCommand
    {
        void CreateBooking(CreateBookingDto createBookingDto);
        void UpdateBooking(UpdateBookingDto updateBookingDto);
    }
}

