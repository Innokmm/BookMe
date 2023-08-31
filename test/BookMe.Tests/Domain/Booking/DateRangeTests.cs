using BookMe.Domain.Bookings;

namespace BookMe.Tests.Domain.Booking
{
    public class DateRangeTests
    {
        [Theory]
        [MemberData(nameof(StartDateIsEqualToOrAfterEndDateData))]
        public void ShouldThrowException_WhenStartDateIsEqualToOrAfterEndDate(DateOnly start, DateOnly end)
        {
            //Arrange
            //Act
            void Act() => _ = DateRange.Create(start, end);

            //Assert
            var exception = Assert.Throws<ApplicationException>(Act);
            Assert.Equal("End date must be after start date", exception.Message);
        }

        public static IEnumerable<object[]> StartDateIsEqualToOrAfterEndDateData =>
            new List<object[]>
            {
                new object[] { new DateOnly(2023, 1, 02), new DateOnly(2023, 1, 01) },
                new object[] { new DateOnly(2023, 12, 31), new DateOnly(2023, 12, 30) },
                new object[] { new DateOnly(2023, 1, 1), new DateOnly(2023, 1, 1) },
            };

        [Theory]
        [MemberData(nameof(StartDateIsBeforeEndDateData))]
        public void ShouldCreateExpectedDateRangeWithExpectedLengthInDays_WhenStartDateIsBeforeEndDate(DateOnly start, DateOnly end, int expectedLengthInDays)
        {
            //Arrange
            //Act
            var dateRange = DateRange.Create(start, end);

            //Assert
            Assert.NotNull(dateRange);
            Assert.Equal(expectedLengthInDays, dateRange.LengthInDays);
        }

        public static IEnumerable<object[]> StartDateIsBeforeEndDateData =>
            new List<object[]>
            {
                new object[] { new DateOnly(2023, 12, 30), new DateOnly(2023, 12, 31), 1 },
                new object[] { new DateOnly(2023, 12, 1), new DateOnly(2023, 12, 31), 30 },
            };
    }
}
