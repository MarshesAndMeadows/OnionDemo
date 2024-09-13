using OnionDemo.Application.Command.CommandDTO;
using OnionDemo.Application.Helpers;
using OnionDemo.Application.Query.QueryDTO;
using OnionDemo.Domain.DomainServices;
using OnionDemo.Domain.Entity;

namespace OnionDemo.Application.Command
{
    public class BookingCommand(IBookingRepository repository, IBookingDomainService domainService)
        : IBookingCommand
    {
        private readonly IUnitOfWork _unitOfWork;

        void IBookingCommand.CreateBooking(CreateBookingDto bookingDto)
        {
            try
            {
                _unitOfWork.BeginTransaction();

                // Do
                var booking = Booking.Create(bookingDto.StartDate, bookingDto.EndDate, domainService);

                // Save
                repository.AddBooking(booking);

                _unitOfWork.Commit();
            }
            catch (Exception)
            {
                _unitOfWork.Rollback();
                throw;
            }
        }
        void IBookingCommand.UpdateBooking(UpdateBookingDto updateBookingDto)
        {
            try
            {
                _unitOfWork.BeginTransaction();

                // Load
                var booking = repository.GetBooking(updateBookingDto.Id);

                // Do
                booking.Update(updateBookingDto.StartDate, updateBookingDto.EndDate, domainService);

                // Save
                repository.UpdateBooking(booking, updateBookingDto.RowVersion);

                _unitOfWork.Commit();
            }
            catch (Exception)
            {
                _unitOfWork.Rollback();
                throw;
            }
        }
        void IBookingCommand.DeleteBooking(DeleteBookingDto deleteBookingDto)
        {
            // Load
            var booking = repository.GetBooking(deleteBookingDto.Id);
            // Save
            repository.DeleteBooking(booking, deleteBookingDto.RowVersion);
        }


    }
}
