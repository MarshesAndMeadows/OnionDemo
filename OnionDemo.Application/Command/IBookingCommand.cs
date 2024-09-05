using OnionDemo.Application.Command.CommandDTO;

namespace OnionDemo.Application.Command
{
    public interface IBookingCommand
    {
        void CreateBooking(CreateBookingDto createBookingDto);
        void UpdateBooking(UpdateBookingDto updateBookingDto);
        void DeleteBooking(DeleteBookingDto deleteBookingDto);
    }
}
