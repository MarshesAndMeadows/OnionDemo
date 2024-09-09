using OnionDemo.Application.Command.CommandDTO;
using OnionDemo.Domain.DomainServices;
using OnionDemo.Domain.Entity;

namespace OnionDemo.Application.Command
{
    public class BookingCommand : IBookingCommand
    {
        private readonly IBookingRepository _repository;
        private readonly IBookingDomainService _domainService;

        public BookingCommand(IBookingRepository repository, IBookingDomainService domainService)
        {
            _repository = repository;
            _domainService = domainService;
        }
        void IBookingCommand.CreateBooking(CreateBookingDto bookingDto)
        {
            // Do
            var booking = Booking.Create(bookingDto.StartDate, bookingDto.EndDate, _domainService);

            // Save
            _repository.AddBooking(booking);
        }

        void IBookingCommand.UpdateBooking(UpdateBookingDto updateBookingDto)
        {
            // Load
            var booking = _repository.GetBooking(updateBookingDto.Id);

            // Do
            booking.Update(updateBookingDto.StartDate, updateBookingDto.EndDate, _domainService);

            // Save
            _repository.UpdateBooking(booking, updateBookingDto.RowVersion);
        }

        void IBookingCommand.DeleteBooking(DeleteBookingDto deleteBookingDto)
        {
            // Load
            var booking = _repository.GetBooking(deleteBookingDto.Id);
            // Save
            _repository.DeleteBooking(booking.Id);
        }


    }
}
