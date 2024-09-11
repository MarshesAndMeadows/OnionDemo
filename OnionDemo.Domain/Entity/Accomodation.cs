﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionDemo.Domain.Entity
{
    public class Accomodation
    {
        protected Accomodation(){ }
        public int Id { get; private set; }
        public IEnumerable<Booking> Bookings { get; private set; }
        public Host host { get; private set; }
    }
}