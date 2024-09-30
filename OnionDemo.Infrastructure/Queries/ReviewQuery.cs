using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnionDemo.Application.Queries.BookingQuery;
using OnionDemo.Application.Queries.ReviewQuery;

namespace OnionDemo.Infrastructure.Queries
{
    public class ReviewQuery(BookMyHomeContext db) : IReviewQuery
    {
        private readonly BookMyHomeContext _db = db;

        ReviewDto IReviewQuery.Get(int Id)
        {
            var review = db.Reviews.AsNoTracking().Single(r => r.Id == Id);

            return new ReviewDto
            {
                Id = review.Id,
                Blurb = review.Blurb,
                Rating = review.Rating,
                RowVersion = review.RowVersion
            };
        }
    }
}
