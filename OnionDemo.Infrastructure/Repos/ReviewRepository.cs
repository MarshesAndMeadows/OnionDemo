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
    public class ReviewRepository : IReviewRepository
    {
        private readonly BookMyHomeContext _db;
        public ReviewRepository(BookMyHomeContext db)
        {
            _db = db;
        }
        Review IReviewRepository.Get(int id)
        {
            return _db.Reviews.Single(a => a.Id == id);
        }


    }
}
