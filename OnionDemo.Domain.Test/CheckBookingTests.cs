﻿using OnionDemo.Domain.DomainServices;
using OnionDemo.Domain.Entity;
using OnionDemo.Domain.Test.Fakes;

namespace OnionDemo.Domain.Test
{
    /// <summary>
    /// Se https://www.milanjovanovic.tech/blog/creating-data-driven-tests-with-xunit
    /// Og https://www.c-sharpcorner.com/blogs/datadriven-testing-with-xunit-in-net-80
    /// </summary>
    public class CheckBookingTests
    {
        [Theory]
        [MemberData(nameof(BookingTestDataWithOverlap))]
        public void Given_Booking_Overlap__Then_Throw_Exception(Booking booking, List<Booking> otherBookings)
        {
            // Arrange
            var sut = new FakeBooking(booking.StartDate, booking.EndDate);

            // Act & Assert

            Assert.Throws<Exception>(() => sut.AssureNoOverlapping(otherBookings));
        }

        [Theory]
        [MemberData(nameof(BookingTestDataWithNoOverlap))]
        public void Given_No_Booking_Overlap__Then_Returns_Void(Booking booking, List<Booking> otherBookings)
        {
            // Arrange
            var sut = new FakeBooking(booking.StartDate, booking.EndDate);

            // Act & Assert
            sut.AssureNoOverlapping(otherBookings);
        }

        public static IEnumerable<object[]> BookingTestDataWithOverlap()
        {
            var otherBookings = CreateOtherBookings();

            yield return
            [
                new FakeBooking(
                    new DateOnly(2024, 8, 28),
                    new DateOnly(2024, 8, 29)), otherBookings
            ]; // Overlapper med booking 1

            yield return
            [
                new FakeBooking(
                    new DateOnly(2024, 8, 20),
                    new DateOnly(2024, 8, 27)), otherBookings
            ]; // Overlapper med booking 1

            yield return
            [
                new FakeBooking(
                    new DateOnly(2024, 8, 30),
                    new DateOnly(2024, 8, 31)), otherBookings
            ]; // Overlapper med booking 1

            yield return
            [
                new FakeBooking(
                    new DateOnly(2024, 8, 30),
                    new DateOnly(2024, 8, 1)), otherBookings
            ]; // Overlapper med booking 1 og 2

        }

        public static IEnumerable<object[]> BookingTestDataWithNoOverlap()
        {
            var otherBookings = CreateOtherBookings();

            yield return
            [
                new FakeBooking(
                    new DateOnly(2024, 8, 1),
                    new DateOnly(2024, 8, 20)), otherBookings
            ]; // Before

            yield return
            [
                new FakeBooking(
                    new DateOnly(2024, 9, 8),
                    new DateOnly(2024, 9, 9)), otherBookings
            ]; // Between

            yield return
            [
                new FakeBooking(
                    new DateOnly(2024, 10, 1),
                    new DateOnly(2024, 10, 20)), otherBookings
            ]; // After

            yield return
            [
                new FakeBooking(
                    new DateOnly(2024, 8, 30),
                    new DateOnly(2024, 8, 1)), otherBookings
            ]; // Overlapper med booking 1 og 2

        }

        private static List<Booking> CreateOtherBookings()
        {
            var otherBookings = new List<Booking>(new[]
            {
                new FakeBooking(
                    new DateOnly(2024, 8, 27),
                    new DateOnly(2024, 8, 30))
                ,
                new FakeBooking(
                    new DateOnly(2024, 9, 1),
                    new DateOnly(2024, 9, 7))
                ,
                new FakeBooking(
                    new DateOnly(2024, 9, 10),
                    new DateOnly(2024, 9, 17))
            });
            return otherBookings;
        }
    }
}

/*using Moq;
using OnionDemo.Domain.DomainServices;
using OnionDemo.Domain.Entity;
using OnionDemo.Domain.Test.Fakes;

namespace OnionDemo.Domain.Test
{
    public class CheckBookingTests
    {

        [Theory]
        [MemberData(nameof(bookingTestDataWithOverlap))]
        public void Given_Booking_Overlap__Then_Throws_Exception(Booking booking, List<Booking> bookingDataWithOverlap)
        {
            //A
            var sut = new FakeBooking(booking.StartDate,booking.EndDate);

            //AA
            var result = sut.IsOverlapping(booking, bookingDataWithOverlap);

            //AAA
            Assert.Throws<Exception>(() => sut.AssureNoOverlapping(otherBookings));
        }

        [Theory]
        [MemberData(nameof(bookingTestDataWithOverlap))]
        public void Given_Booking_Overlap__Then_Throws_Exception(Booking booking, List<Booking> bookingDataWithOverlap)
        {
            //A
            var sut = new FakeBooking(booking.StartDate, booking.EndDate);

            //AA&AAA
            sut.AssureNoOverlapping(otherBookings);
        }

        public static IEnumerable<object[]> BookingTestDataWithOverlap()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public void Given_Booking_Overlaps__Then_Throw_Exc()
        {
            //A
            var overlappingMock = new Mock<IBookingDomainService>();
            var otherBookings = new List<Booking>()
            {
                new FakeBooking(DateOnly.FromDateTime(DateTime.Now.AddDays(-2)), DateOnly.FromDateTime(DateTime.Now.AddDays(1))),
                new FakeBooking(DateOnly.FromDateTime(DateTime.Now.AddDays(1)), DateOnly.FromDateTime(DateTime.Now.AddDays(2))),
                new FakeBooking(DateOnly.FromDateTime(DateTime.Now), DateOnly.FromDateTime(DateTime.Now.AddDays(2))),
            };
            var now = DateOnly.FromDateTime(DateTime.Now);
            var sut = new BookingDomainService();

            //AAe
            var booking = Booking.Create(
            DateOnly.FromDateTime(DateTime.Now.AddDays(1)),
            DateOnly.FromDateTime(DateTime.Now.AddDays(3)),
            overlappingMock.Object,
            otherBookings
            );

            //AAA
            Assert.NotNull(booking);
        }
    }
}
*/