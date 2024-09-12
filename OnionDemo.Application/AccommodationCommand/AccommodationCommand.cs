using OnionDemo.Application.Command.CommandDTO;
using OnionDemo.Application.Command;
using OnionDemo.Application.Helpers;
using OnionDemo.Domain.DomainServices;
using OnionDemo.Domain.Entity;
using OnionDemo.Application.AccommodationCommand.CommandDTO;

namespace OnionDemo.Application.AccommodationCommand
{
    public class AccommodationCommand : IAccommodationCommand
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IAccommodationRepository _repository;

        public AccommodationCommand(IAccommodationRepository repository)
        {
            _repository = repository;
        }

        public AccommodationCommand(){}

        void IAccommodationCommand.CreateAccommodation(CreateAccommodationDto createAccommodationDto)
        {
            try
            {
                _unitOfWork.BeginTransaction();

                // Do
                var accommodation = Accommodation.Create();

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
    }
}
