using OnionDemo.Application.Commands.CommandDTO.Accommodation;
using OnionDemo.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnionDemo.Application.Commands.CommandDTO.Review;
using OnionDemo.Application.Helpers;
using OnionDemo.Application.Queries.BookingQuery;
using OnionDemo.Application.Interfaces;

namespace OnionDemo.Application.Commands
{
    public class ReviewCommand(
        IAccommodationRepository repository,
        IReviewRepository reviewRepository,
        IUnitOfWork uow) : IReviewCommand
    {

        void IReviewCommand.Create(CreateReviewDto createReviewDto)
        {

            try
            {
                uow.BeginTransaction();

                //Load
                var booking = repository.GetBooking(createReviewDto.BookingId);
                var review = Review.Create(createReviewDto.Rating, createReviewDto.Blurb);

                // Do
                booking.AddReview(review);
                reviewRepository.AddReview(review);

                // Save
                uow.Commit();
            }
            catch (Exception e)
            {
                try
                {
                    uow.Rollback();
                }
                catch (Exception ex)
                {
                    throw new Exception($"Rollback failed! {ex.Message}", e);
                }

                throw;
            }
        }
    }
}
