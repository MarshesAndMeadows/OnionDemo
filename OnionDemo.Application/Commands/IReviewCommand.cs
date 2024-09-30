using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnionDemo.Application.Commands.CommandDTO.Review;

namespace OnionDemo.Application.Commands
{
    public interface IReviewCommand
    {
        void Create(CreateReviewDto createReviewDto);
    }
}
