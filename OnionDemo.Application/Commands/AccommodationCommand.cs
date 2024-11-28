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
        private readonly IGuestRepository _guestRepository;

        public AccommodationCommand(IAccommodationRepository repository, IUnitOfWork uow, IHostRepository hostRepository, IReviewRepository reviewRepository, IGuestRepository guestRepository)
        {
            _repository = repository;
            _uow = uow;
            _hostRepository = hostRepository;
            _reviewRepository = reviewRepository;
            _guestRepository = guestRepository;
        }

        async void IAccommodationCommand.Create(CreateAccommodationDto createDto)
        {
            var addressExists = await _repository.ValidateAddress(createDto.Address);
            if (addressExists)
            {
                var address = createDto.Address;
                var host = _hostRepository.Get(createDto.HostId);
                var accommodation = Accommodation.Create(host, address);
                host.AddAccommodation(accommodation);
                _repository.Add(accommodation);
            }
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
                var guest = _guestRepository.Get(bookingDto.guestId);

                // Do
                accommodation.AddBooking(guest, bookingDto.StartDate, bookingDto.EndDate);

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
                var guest = _guestRepository.Get(updateBookingDto.GuestId);
                // Do
                var booking = accommodation.UpdateBooking(guest, updateBookingDto.Id, updateBookingDto.StartDate, updateBookingDto.EndDate);

                // Save
                var rowVersion = _uow.ConvertHexToByteArray(updateBookingDto.RowVersion);
                _repository.UpdateBooking(booking, rowVersion);

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
