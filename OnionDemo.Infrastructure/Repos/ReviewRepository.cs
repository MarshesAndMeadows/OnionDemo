using OnionDemo.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnionDemo.Application.Queries.BookingQuery;
using OnionDemo.Domain.Entity;

namespace OnionDemo.Infrastructure.Repos
{
    public class ReviewRepository(BookMyHomeContext db) : IReviewRepository
    {
        Review IReviewRepository.Get(int id)
        {
            return db.Reviews.Single(a => a.Id == id);
        }

        void IReviewRepository.AddReview(Review review)
        {
            db.Reviews.Add(review);
            db.SaveChanges();
        }

    }
}
