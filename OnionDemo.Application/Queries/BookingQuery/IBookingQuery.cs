namespace OnionDemo.Application.Queries.BookingQuery
{
    public interface IBookingQuery
    {
        BookingDto GetBooking(int id);

        IEnumerable<BookingDto> GetBookings();
    }

}
