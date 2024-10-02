﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnionDemo.Application.Queries.AccommodationQuery;
using OnionDemo.Application.Queries.BookingQuery;
using OnionDemo.Application.Queries.HostQuery;
using OnionDemo.Application.Queries.ReviewQuery;
using OnionDemo.Domain.Entity;

namespace OnionDemo.Infrastructure.Queries
{
    public class HostQuery(BookMyHomeContext db) : IHostQuery
    {
        HostDto? IHostQuery.GetAccommodations(int hostId)
        {
            var host = db.Hosts
                .Include(a => a.Accommodations)
                .ThenInclude(a => a.Bookings)
                .FirstOrDefault(h => h.Id == hostId);

            if (host == null) return null;

            return new HostDto
            {
                Id = host.Id,
                Accommodations = host.Accommodations.Select(a => new AccommodationDTO
                {
                    Id = a.Id,
                    HostId = a.Host.Id,
                    Bookings = a.Bookings.Select(b => new BookingDto
                    {
                        Id = b.Id,
                        StartDate = b.StartDate,
                        EndDate = b.EndDate,
                        RowVersion = b.RowVersion,
                        Review = new ReviewDto()
                        {
                            Blurb = b.Review.Blurb,
                            Rating = b.Review.Rating
                        },
                        AccommodationId = a.Id,
                    })
                })
            };
        }
    }
}
