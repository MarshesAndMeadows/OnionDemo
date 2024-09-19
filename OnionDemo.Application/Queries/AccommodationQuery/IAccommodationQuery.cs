namespace OnionDemo.Application.Queries.AccommodationQuery
{
    public interface IAccommodationQuery
    {
        AccommodationDTO GetAccommodation(int id);

        IEnumerable<AccommodationDTO> GetAccommodations();
    }
}
