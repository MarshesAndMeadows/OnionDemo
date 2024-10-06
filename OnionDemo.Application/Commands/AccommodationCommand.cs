using OnionDemo.Application.Helpers;
using OnionDemo.Domain.Entity;
using OnionDemo.Application.Queries.BookingQuery;
using OnionDemo.Application.Commands.CommandDTO.Accommodation;
using OnionDemo.Application.Commands.CommandDTO.Booking;
using OnionDemo.Application.Interfaces;

namespace OnionDemo.Application.Commands
{
    public class AccommodationCommand : IAccommodationCommand
    {
        private readonly IUnitOfWork _uow;
        private readonly IAccommodationRepository _repository;
        private readonly IHostRepository _hostRepository;
        private readonly IReviewRepository _reviewRepository;

        public AccommodationCommand(IAccommodationRepository repository, IUnitOfWork uow, IHostRepository hostRepository, IReviewRepository reviewRepository)
        {
            _repository = repository;
            _uow = uow;
            _hostRepository = hostRepository;
            _reviewRepository = reviewRepository;
        }
        
                void IAccommodationCommand.Create(CreateAccommodationDto createDto)
                {
                    _repository.ValidateAddress(createDto.Address);
                    var host = _hostRepository.Get(createDto.HostId);
                    var accommodation = Accommodation.Create(host);
                    _repository.Add(accommodation);
                }

                void IAccommodationCommand.Delete(DeleteAccommodationDto deleteAccommodationDto)
                {
                    throw new NotImplementedException();
                    /*
                    // Load
                    var accommodation = _repository.GetAccommodation(deleteAccommodationDto.Id);
                    // Save
                    _repository.DeleteAccommodation(accommodation, deleteAccommodationDto.RowVersion);
                    */
                }

                void IAccommodationCommand.Update(UpdateAccommodationDto updateAccommodationDto)
                {
                    throw new NotImplementedException();
                    /*try
                    {
                        _uow.BeginTransaction();

                        // Load
                        var accommodation = _repository.GetAccommodation(updateAccommodationDto.Id);

                        // Do
                        accommodation.Update(accommodation, updateAccommodationDto.RowVersion);

                        // Save
                        _repository.UpdateAccommodation(accommodation, updateAccommodationDto.RowVersion);

                        _uow.Commit();
                    }
                    catch (Exception)
                    {
                        _uow.Rollback();
                        throw;
                    }*/
                }

        void IAccommodationCommand.CreateBooking(CreateBookingDto bookingDto)
        {
            try
            {
                _uow.BeginTransaction();

                //Load
                Accommodation accommodation = _repository.GetAccommodation(bookingDto.AccommodationId);

                // Do
                accommodation.AddBooking(bookingDto.StartDate, bookingDto.EndDate);

                // Save
                _repository.AddBooking(accommodation);

                _uow.Commit();
            }
            catch (Exception e)
            {
                try
                {
                    _uow.Rollback();
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
                _uow.BeginTransaction();

                //Load
                Accommodation accommodation = _repository.GetAccommodation(updateBookingDto.AccommodationId);
                var review = _reviewRepository.Get(updateBookingDto.reviewId);

                // Do
                var booking = accommodation.UpdateBooking(updateBookingDto.Id, updateBookingDto.StartDate, updateBookingDto.EndDate, review);

                // Save
                _repository.UpdateBooking(booking, updateBookingDto.RowVersion);

                _uow.Commit();
            }
            catch (Exception e)
            {
                try
                {
                    _uow.Rollback();
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
            throw new NotImplementedException();
        }
    }
}
