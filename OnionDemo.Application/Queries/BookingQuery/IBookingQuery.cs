namespace OnionDemo.Application.Queries.BookingQuery
{
    public interface IBookingQuery
    {
        BookingDto GetBooking(int accommodationId, int bookingId);
        IEnumerable<BookingDto> GetBookings(int accommodationId);
    }

}
