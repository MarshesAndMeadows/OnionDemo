using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionDemo.Application.Queries.ReviewQuery
{
    public interface IReviewQuery
    {
        ReviewDto Get(int Id);

    }
}
