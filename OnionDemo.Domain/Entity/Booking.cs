using OnionDemo.Domain.DomainServices;
using System.ComponentModel.DataAnnotations;

namespace OnionDemo.Domain.Entity;

public abstract class DomainEntity
{
    public int Id { get; protected set; }
    [Timestamp]
    public byte[] RowVersion { get; protected set; } = null!;
}


public class Booking : DomainEntity
{

    protected Booking(){}

    private Booking(DateOnly startDate, DateOnly endDate, IBookingDomainService bookingDomainService)
    {
        StartDate = startDate;
        EndDate = endDate;
        AssureStartDateBeforeEndDate(startDate, endDate);
        AssureBookingMustBeInFuture(startDate, DateOnly.FromDateTime(DateTime.Now));
        AssureNoOverlapping(bookingDomainService.GetOtherBookings(this));
    }
    public DateOnly StartDate { get; protected set; }
    public DateOnly EndDate { get; protected set; }

    public static Booking Create(DateOnly startDate, DateOnly endDate, IBookingDomainService bookingDomainService)
    {
        return new Booking(startDate, endDate, bookingDomainService);
    }


    public void Update(DateOnly startDate, DateOnly endDate, IBookingDomainService bookingDomainService)
    {
        StartDate = startDate;
        EndDate = endDate;

        AssureStartDateBeforeEndDate(startDate, endDate);
        AssureBookingMustBeInFuture(startDate, DateOnly.FromDateTime(DateTime.Now));
        AssureNoOverlapping(bookingDomainService.GetOtherBookings(this));
    }

    protected void AssureBookingMustBeInFuture(DateOnly startDate, DateOnly now)
    {
        if (startDate <= now)
            throw new ArgumentException();
    }

    protected void AssureStartDateBeforeEndDate(DateOnly startDate, DateOnly endDate)
    {
        if (!(startDate < endDate))
        {
            throw new ArgumentException("Start date must be before the end date.");
        }
    }

    protected void AssureNoOverlapping(IEnumerable<Booking> otherBookings)
    {
        if (otherBookings.Any(b => b.StartDate <= EndDate && b.EndDate >= StartDate)) return;
        throw new ArgumentException("Booking overlaps with another booking.");
    }
}