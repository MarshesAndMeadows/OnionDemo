using OnionDemo.Application.Helpers;
using OnionDemo.Domain.DomainServices;
using OnionDemo.Domain.Entity;
using OnionDemo.Application.Commands.AccommodationCommand.CommandDTO;
using OnionDemo.Application.Queries.BookingQuery;

namespace OnionDemo.Application.Commands.AccommodationCommand
{
    public class AccommodationCommand : IAccommodationCommand
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAccommodationRepository _repository;

        public AccommodationCommand(IAccommodationRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }
/*
        public void CreateAccommodation(CreateAccommodationDto createAccommodationDto)
        {
            try
            {
                _unitOfWork.BeginTransaction();
                //Load
                var host = Host.GetHost(createAccommodationDto.Host.Id);

                // Do
                var accommodation = Accommodation.Create(host);

                // Save
                _repository.AddAccommodation(accommodation);

                _unitOfWork.Commit();
            }
            catch (Exception)
            {
                _unitOfWork.Rollback();
                throw;
            }
        }

        void IAccommodationCommand.DeleteAccommodation(DeleteAccommodationDto deleteAccommodationDto)
        {
            // Load
            var accommodation = _repository.GetAccommodation(deleteAccommodationDto.Id);
            // Save
            _repository.DeleteAccommodation(accommodation, deleteAccommodationDto.RowVersion);
        }

        void IAccommodationCommand.UpdateAccommodation(UpdateAccommodationDto updateAccommodationDto)
        {
            try
            {
                _unitOfWork.BeginTransaction();

                // Load
                var accommodation = _repository.GetAccommodation(updateAccommodationDto.Id);

                // Do
                accommodation.Update(accommodation, updateAccommodationDto.RowVersion);

                // Save
                _repository.UpdateAccommodation(accommodation, updateAccommodationDto.RowVersion);

                _unitOfWork.Commit();
            }
            catch (Exception)
            {
                _unitOfWork.Rollback();
                throw;
            }
        }
*/
        void IAccommodationCommand.CreateBooking(CreateBookingDto bookingDto)
        {
            try
            {
                _unitOfWork.BeginTransaction();
                
                //Load
                Accommodation accommodation = _repository.GetAccommodation(bookingDto.AccommodationId);

                // Do
                accommodation.CreateBooking(bookingDto.StartDate, bookingDto.EndDate);

                // Save
                _repository.AddBooking(accommodation);

                _unitOfWork.Commit();
            }
            catch (Exception e)
            {
                try
                {
                    _unitOfWork.Rollback();
                }
                catch (Exception ex)
                {
                    throw new Exception($"Rollback failed! {ex.Message}", e);
                }

                throw;
            }
        }

        void IAccommodationCommand.UpdateBooking(UpdateBookingDto updateBookingDto)
        {
            try
            {
                _unitOfWork.BeginTransaction();

                //Load
                Accommodation accommodation = _repository.GetAccommodation(updateBookingDto.AccommodationId);

                // Do
                var booking = accommodation.UpdateBooking(updateBookingDto.Id, updateBookingDto.StartDate, updateBookingDto.EndDate);

                // Save
                _repository.UpdateBooking(booking, updateBookingDto.RowVersion);

                _unitOfWork.Commit();
            }
            catch (Exception e)
            {
                try
                {
                    _unitOfWork.Rollback();
                }
                catch (Exception ex)
                {
                    throw new Exception($"Rollback failed! {ex.Message}", e);
                }

                throw;
            }
        }

        void IAccommodationCommand.DeleteBooking(DeleteBookingDto deleteBookingDto)
        {
            // Load
            var booking = _repository.GetBooking(deleteBookingDto.Id);
            // Save
            _repository.DeleteBooking(booking, deleteBookingDto.RowVersion);
        }
    }
}
