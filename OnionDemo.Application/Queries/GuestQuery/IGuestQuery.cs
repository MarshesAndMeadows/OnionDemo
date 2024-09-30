using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionDemo.Application.Queries.GuestQuery
{
    public interface IGuestQuery
    {
        GuestDto GetBookings(int guestId);
    }
}
