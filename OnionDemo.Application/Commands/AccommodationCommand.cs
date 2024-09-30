using OnionDemo.Application.Helpers;
using OnionDemo.Domain.Entity;
using OnionDemo.Application.Queries.BookingQuery;
using OnionDemo.Application.Commands.CommandDTO.Accommodation;
using OnionDemo.Application.Commands.CommandDTO.Booking;

namespace OnionDemo.Application.Commands
{
    public class AccommodationCommand(
        IAccommodationRepository repository,
        IUnitOfWork uow,
        IHostRepository hostRepository,
        IReviewRepository reviewRepository) : IAccommodationCommand
    {
        void IAccommodationCommand.Create(CreateAccommodationDto createAccommodationDto)
        {
            var host = hostRepository.Get(createAccommodationDto.HostId);
            var accommodation = Accommodation.Create(host);
            repository.Add(accommodation);
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
                uow.BeginTransaction();

                //Load
                Accommodation accommodation = repository.GetAccommodation(bookingDto.AccommodationId);

                // Do
                accommodation.CreateBooking(bookingDto.StartDate, bookingDto.EndDate);

                // Save
                repository.AddBooking(accommodation);

                uow.Commit();
            }
            catch (Exception e)
            {
                try
                {
                    uow.Rollback();
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
                uow.BeginTransaction();

                //Load
                Accommodation accommodation = repository.GetAccommodation(updateBookingDto.AccommodationId);
                var review = reviewRepository.Get(updateBookingDto.reviewId);

                // Do
                var booking = accommodation.UpdateBooking(updateBookingDto.Id, updateBookingDto.StartDate, updateBookingDto.EndDate, review);

                // Save
                repository.UpdateBooking(booking, updateBookingDto.RowVersion);

                uow.Commit();
            }
            catch (Exception e)
            {
                try
                {
                    uow.Rollback();
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
