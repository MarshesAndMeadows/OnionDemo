using OnionDemo.Application.AccommodationQuery.QueryDTO;

namespace OnionDemo.Application.AccommodationQuery
{
    public interface IAccommodationQuery
    {
        AccommodationDTO GetAccommodation(int id);

        IEnumerable<AccommodationDTO> GetAccommodations();
    }
}
