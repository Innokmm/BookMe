using BookMe.Domain.Apartments;

namespace BookMe.Tests.Domain.Apartments
{
    public class CurrencyTests
    {
        [Theory]
        [InlineData(null)]
        [InlineData("invalid code")]
        public void ShouldThrowException_WhenGetCurrencyFromNonExistingCode(string code)
        {
            //Arrange
            //Act
            void Act() => _ = Currency.FromCode(code);

            //Assert
            var exception = Assert.Throws<ApplicationException>(Act);
            Assert.Equal("The currency code is invalid", exception.Message);
        }

        [Theory]
        [MemberData(nameof(Data))]
        public void ShouldReturnExpectedCurrency_WhenGetCurrencyFromNonExistingCode(string code, Currency expectedCurrency)
        {
            //Arrange
            //Act
            var currency = Currency.FromCode(code);

            //Assert
            Assert.Equal(expectedCurrency, currency);
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { "usd", Currency.Usd },
                new object[] { "uSd", Currency.Usd },
                new object[] { "EUR", Currency.Eur }
            };
    }
}
