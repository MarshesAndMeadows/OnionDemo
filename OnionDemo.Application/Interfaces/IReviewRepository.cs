using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnionDemo.Domain.Entity;

namespace OnionDemo.Application.Interfaces
{
    public interface IReviewRepository
    {
        Review Get(int id);
        void AddReview(Review review);

    }
}
