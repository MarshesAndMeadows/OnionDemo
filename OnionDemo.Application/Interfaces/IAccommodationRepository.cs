﻿using OnionDemo.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionDemo.Application.Interfaces
{
    public interface IAccommodationRepository
    {
        Accommodation GetAccommodation(int id);
        void AddBooking(Accommodation accommodation);
        void UpdateBooking(Booking booking, byte[] rowversion);
        void Add(Accommodation accommodation);
        Booking GetBooking(int id);

        Task<bool> ValidateAddress(string address);
    }
}
