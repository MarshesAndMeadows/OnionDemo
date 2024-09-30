using OnionDemo.Domain.Entity;

namespace OnionDemo.Domain.Test.Fakes
{
    internal class FakeBooking : Booking
    {
        public FakeBooking(DateOnly startDate, DateOnly endDate) : base()
        {
            StartDate = startDate;
            EndDate = endDate;
        }
    
        public new void AssureNoOverlapping(IEnumerable<Booking> otherBookings)
        {
            {
                base.AssureNoOverlapping(otherBookings);
            }
        }
    }
}