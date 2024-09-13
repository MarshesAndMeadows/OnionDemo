using Microsoft.EntityFrameworkCore;
using OnionDemo.Application.Query;
using OnionDemo.Application.Query.QueryDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnionDemo.Application.AccommodationQuery;
using OnionDemo.Application.AccommodationQuery.QueryDTO;

namespace OnionDemo.Infrastructure.Queries
{
    public class AccommodationQuery(BookMyHomeContext db) : IAccommodationQuery
    {
        AccommodationDTO IAccommodationQuery.GetAccommodation(int id)
        {
            var accommodation = db.Bookings.AsNoTracking().Single(a => a.Id == id);
            return new AccommodationDTO
            {
                Id = accommodation.Id,
                RowVersion = accommodation.RowVersion
            };
        }

        IEnumerable<AccommodationDTO> IAccommodationQuery.GetAccommodations()
        {
            var result = db.Accommodations.AsNoTracking().
                Select(a => new AccommodationDTO
                {
                    Id = a.Id,

                });
            return result;
        }
    }
}