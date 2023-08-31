using BookMe.Domain.Bookings;

namespace BookMe.Tests.Domain.Booking
{
    public class DateRangeTests
    {
        [Theory]
        [MemberData(nameof(StartDateAfterEndDateData))]
        public void ShouldThrowException_WhenStartDateIsAfterEndDate(DateOnly start, DateOnly end)
        {
            //Arrange
            //Act
            void Act() => _ = DateRange.Create(start, end);

            //Assert
            var exception = Assert.Throws<ApplicationException>(Act);
            Assert.Equal("Start date cannot be after end date", exception.Message);
        }

        public static IEnumerable<object[]> StartDateAfterEndDateData =>
            new List<object[]>
            {
                new object[] { new DateOnly(2023, 1, 02), new DateOnly(2023, 1, 01) },
                new object[] { new DateOnly(2023, 12, 31), new DateOnly(2023, 12, 30) },
            };

        [Theory]
        [MemberData(nameof(StartDateEqualToOrBeforeEndDateData))]
        public void ShouldCreateExpectedDateRangeWithExpectedLengthInDays_WhenStartDateEqualToOrBeforeEndDate(DateOnly start, DateOnly end, int expectedLengthInDays)
        {
            //Arrange
            //Act
            var dateRange = DateRange.Create(start, end);

            //Assert
            Assert.NotNull(dateRange);
            Assert.Equal(expectedLengthInDays, dateRange.LengthInDays);
        }

        public static IEnumerable<object[]> StartDateEqualToOrBeforeEndDateData =>
            new List<object[]>
            {
                new object[] { new DateOnly(2023, 1, 1), new DateOnly(2023, 1, 1), 0 },
                new object[] { new DateOnly(2023, 12, 30), new DateOnly(2023, 12, 31), 1 },
                new object[] { new DateOnly(2023, 12, 1), new DateOnly(2023, 12, 31), 30 },
            };
    }
}
