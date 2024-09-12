using OnionDemo.Application.AccommodationCommand.CommandDTO;

namespace OnionDemo.Application.AccommodationCommand
{
    public interface IAccommodationCommand
    {
        void CreateAccommodation(CreateAccommodationDto createAccommodationDto);
        void UpdateAccommodation(UpdateAccommodationDto updateAccommodationDto);
        void DeleteAccommodation(DeleteAccommodationDto deleteAccommodationDto);
    }
}
