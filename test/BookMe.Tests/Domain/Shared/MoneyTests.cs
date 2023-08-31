using BookMe.Domain.Shared;

namespace BookMe.Tests.Domain.Shared;

public class MoneyTests
{
    [Fact]
    public void ShouldThrowException_WhenAddingMoneyWithDifferentCurrencies()
    {
        //Arrange
        var money1 = new Money(1, Currency.Usd);
        var money2 = new Money(1, Currency.Eur);

        //Act
        void Act() => _ = money1 + money2;

        //Assert
        var exception = Assert.Throws<InvalidOperationException>(Act);
        Assert.Equal("Currencies are different", exception.Message);
    }

    [Theory]
    [MemberData(nameof(Data))]
    public void ShouldCreateMoneyWithCorrectAmountAndCurrency_WhenAddingSameCurrency(decimal value1, decimal value2,
        Currency currency)
    {
        //Arrange
        var money1 = new Money(value1, currency);
        var money2 = new Money(value2, currency);

        //Act
        var result = money1 + money2;

        //Assert
        Assert.Equal(currency, result.Currency);
        Assert.Equal(value1 + value2, result.Amount);
    }

    public static IEnumerable<object[]> Data =>
        new List<object[]>
        {
            new object[] { 0, 1, Currency.Usd },
            new object[] { 0.03, 0.01, Currency.Usd },
            new object[] { 0.01, 0.02, Currency.Eur }
        };
}