using OnionDemo.Application.Command.CommandDTO;
using OnionDemo.Application.Helpers;
using OnionDemo.Application.Query.QueryDTO;
using OnionDemo.Domain.DomainServices;
using OnionDemo.Domain.Entity;

namespace OnionDemo.Application.Command
{
    public class BookingCommand : IBookingCommand
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBookingRepository _repository;
        private readonly IBookingDomainService _domainService;

        public BookingCommand(IBookingRepository repository, IBookingDomainService domainService)
        {
            _repository = repository;
            _domainService = domainService;
        }
        void IBookingCommand.CreateBooking(CreateBookingDto bookingDto)
        {
            try
            {
                _unitOfWork.BeginTransaction();

                // Do
                var booking = Booking.Create(bookingDto.StartDate, bookingDto.EndDate, _domainService);

                // Save
                _repository.AddBooking(booking);

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
                var booking = _repository.GetBooking(updateBookingDto.Id);

                // Do
                booking.Update(updateBookingDto.StartDate, updateBookingDto.EndDate, _domainService);

                // Save
                _repository.UpdateBooking(booking, updateBookingDto.RowVersion);

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
            var booking = _repository.GetBooking(deleteBookingDto.Id);
            // Save
            _repository.DeleteBooking(booking, deleteBookingDto.RowVersion);
        }


    }
}
