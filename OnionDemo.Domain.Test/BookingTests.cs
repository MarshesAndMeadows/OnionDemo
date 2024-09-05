/*using Moq;
using OnionDemo.Domain.DomainServices;
using OnionDemo.Domain.Entity;

namespace OnionDemo.Domain.Test
{
    public class BookingTests
    {
        [Fact]
        public void Given_Startdate_In_Future__Then_Booking_Created()
        {
            //Arrange
            var overlappingMock = new Mock<IBookingDomainService>();
            var otherBookings = new Mock<List<Booking>>();
            var now = DateOnly.FromDateTime(DateTime.Now);

            //Act
            var booking = Booking.Create(
                DateOnly.FromDateTime(DateTime.Now.AddDays(1)),
                DateOnly.FromDateTime(DateTime.Now.AddDays(3)),
                otherBookings.Object
                );

            //Assert
            Assert.NotNull(booking);
        }



        [Fact]
        public void Given_Startdate_In_Past__Then_Booking_Not_Created()
        {
            var overlappingMock = new Mock<IBookingDomainService>();
            var otherBookings = new Mock<List<Booking>>();
            var now = DateOnly.FromDateTime(DateTime.Now);

            Assert.Throws<ArgumentException>(() => (Booking.Create(
                DateOnly.FromDateTime(DateTime.Now.AddDays(-1)),
                DateOnly.FromDateTime(DateTime.Now.AddDays(1)),
                overlappingMock.Object,
                otherBookings.Object
                )));
        }
    }
}
*/