using BookMe.Domain.Apartments;
using BookMe.Domain.Bookings;
using BookMe.Domain.Shared;

namespace BookMe.Tests.Domain.Booking;

public class PricingServiceTests
{
    private readonly PricingService _service = new();
    private const decimal DefaultPrice = 100;
    private const decimal DefaultCleaningFee = 10;

    [Fact]
    public void ShouldReturnExpectedPricingDetails_WhenApartmentWithoutAmenitiesAndPeriodForOneDayAreProvided()
    {
        //Arrange
        var apartment = CreateTestApartment();
        var period = DateRange.Create(new DateOnly(2023, 01, 01), new DateOnly(2023, 01, 02));

        //Act
        var pricingDetails = _service.CalculatePrice(apartment, period);

        //Assert
        Assert.NotNull(pricingDetails);
        AssertCurrency(Currency.Usd, pricingDetails);

        Assert.Equal(0, pricingDetails.AmenitiesUpCharge.Amount);
        Assert.Equal(DefaultCleaningFee, pricingDetails.CleaningFee.Amount);
        Assert.Equal(DefaultPrice, pricingDetails.PriceForPeriod.Amount);
        Assert.Equal(DefaultPrice + DefaultCleaningFee, pricingDetails.TotalPrice.Amount);
    }

    [Theory]
    [InlineData("USD")]
    [InlineData("EUR")]
    public void ShouldReturnPricingDetailsWithExpectedCurrency_WhenGivenCurrencyIsProvided(string currencyCode)
    {
        //Arrange
        var apartmentWithGivenCurrency = CreateTestApartment(currencyCode: currencyCode);
        var period = DateRange.Create(new DateOnly(2023, 01, 01), new DateOnly(2023, 01, 02));

        //Act
        var pricingDetails = _service.CalculatePrice(apartmentWithGivenCurrency, period);

        //Assert
        AssertCurrency(Currency.FromCode(currencyCode), pricingDetails);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(3)]
    [InlineData(10)]
    public void ShouldReturnExpectedPricingDetails_WhenApartmentWithoutAmenitiesAndPeriodForGivenDaysAreProvided(int days)
    {
        //Arrange
        var apartment = CreateTestApartment();
        var start = new DateOnly(2023, 01, 01);
        var end = start.AddDays(days);
        var periodWithMultipleDays = DateRange.Create(start, end);

        //Act
        var pricingDetails = _service.CalculatePrice(apartment, periodWithMultipleDays);

        //Assert
        Assert.NotNull(pricingDetails);

        Assert.Equal(0, pricingDetails.AmenitiesUpCharge.Amount);
        Assert.Equal(DefaultCleaningFee, pricingDetails.CleaningFee.Amount);
        Assert.Equal(DefaultPrice * days, pricingDetails.PriceForPeriod.Amount);
        Assert.Equal((DefaultPrice * days) + DefaultCleaningFee, pricingDetails.TotalPrice.Amount);
    }

    private Apartment CreateTestApartment(
        decimal price = DefaultPrice, 
        decimal cleaningFee = DefaultCleaningFee, 
        string currencyCode = "usd", 
        List<Amenity>? amenities = null)
    {
        var currency = Currency.FromCode(currencyCode);
        return new Apartment(
            new Guid(),
            new Name("Name"),
            new Description("Description"),
            new Address("Country", "State", "ZipCode", "City", "Street"),
            price,
            cleaningFee,
            currency,
            null,
            amenities ?? new List<Amenity>());
    }

    private static void AssertCurrency(Currency expectedCurrency, PricingDetails pricingDetails)
    {
        Assert.Equal(expectedCurrency, pricingDetails.AmenitiesUpCharge.Currency);
        Assert.Equal(expectedCurrency, pricingDetails.CleaningFee.Currency);
        Assert.Equal(expectedCurrency, pricingDetails.PriceForPeriod.Currency);
        Assert.Equal(expectedCurrency, pricingDetails.TotalPrice.Currency);
    }
}