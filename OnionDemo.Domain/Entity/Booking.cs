using System.ComponentModel.DataAnnotations;

namespace OnionDemo.Domain.Entity;
public class Booking : DomainEntity
{

    protected Booking(){}

    private Booking(DateOnly startDate, DateOnly endDate, IEnumerable<Booking> existingBookings)
    {
        StartDate = startDate;
        EndDate = endDate;

        AssureStartDateBeforeEndDate();
        AssureBookingMustBeInFuture(DateOnly.FromDateTime(DateTime.Now));
        AssureNoOverlapping(existingBookings);
    }

    public DateOnly StartDate { get; protected set; }
    public DateOnly EndDate { get; protected set; }
    public Review? Review { get; protected set; }
    public Guest Guest { get; protected set; }

    public void Update(DateOnly startDate, DateOnly endDate, IEnumerable<Booking> existingBookings)
    {
        StartDate = startDate;
        EndDate = endDate;

        AssureStartDateBeforeEndDate();
        AssureBookingMustBeInFuture(DateOnly.FromDateTime(DateTime.Now));
        AssureNoOverlapping(existingBookings);
    }
    protected void AssureStartDateBeforeEndDate()
    {
        if (!(StartDate < EndDate)) throw new ArgumentException("StartDato skal være før EndDato");
    }
    protected void AssureBookingMustBeInFuture(DateOnly now)
    {
        // Booking skal være i fremtiden
        if (StartDate <= now)
            throw new ArgumentException("Booking skal være i fremtiden");
    }
    protected void AssureNoOverlapping(IEnumerable<Booking> otherBookings)
    {
        if (otherBookings.Any(other =>
                (EndDate <= other.EndDate && EndDate >= other.StartDate) ||
                (StartDate >= other.StartDate && StartDate <= other.EndDate) ||
                (StartDate <= other.StartDate && EndDate >= other.EndDate)))
            throw new Exception("Booking overlapper med en anden booking");
    }
    protected void AssureBookingMustBeInPast(DateOnly now)
    {
        if (StartDate >= now)
            throw new ArgumentException("Booking skal være i fortiden.");
    }

    public static Booking Create(DateOnly startDate, DateOnly endDate, IEnumerable<Booking> existingBookings)
    {
        return new Booking(startDate, endDate, existingBookings);
    }

    public void Update(DateOnly startDate, DateOnly endDate, Review? review, IEnumerable<Booking> existingBookings)
    {
        StartDate = startDate;
        EndDate = endDate;
        Review = review;

        AssureStartDateBeforeEndDate();
        AssureBookingMustBeInFuture(DateOnly.FromDateTime(DateTime.Now));
        AssureNoOverlapping(existingBookings);
    }

    public void AddReview(Review review)
    {
        AssureBookingMustBeInPast(DateOnly.FromDateTime(DateTime.Now));
        try
        {
            Review = review;
            
        }
        catch (Exception e)
        {
            throw new ArgumentException("Rating value must be between 0 and 100.");
        }
    }
}