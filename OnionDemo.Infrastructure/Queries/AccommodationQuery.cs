using Microsoft.EntityFrameworkCore;
using OnionDemo.Application.AccommodationQuery;
using OnionDemo.Application.AccommodationQuery.QueryDTO;

namespace OnionDemo.Infrastructure.Queries
{
    public class AccommodationQuery : IAccommodationQuery
    {
        private readonly BookMyHomeContext _db;

        public AccommodationQuery(BookMyHomeContext db)
        {
            _db = db;
        }
        AccommodationDTO IAccommodationQuery.GetAccommodation(int id)
        {
            var accommodation = _db.Bookings.AsNoTracking().Single(a => a.Id == id);
            return new AccommodationDTO
            {
                Id = accommodation.Id,
                RowVersion = accommodation.RowVersion
            };
        }

        IEnumerable<AccommodationDTO> IAccommodationQuery.GetAccommodations()
        {
            var result = _db.Accommodations.AsNoTracking().
                Select(a => new AccommodationDTO
                {
                    Id = a.Id,

                });
            return result;
        }
    }
}