using BookMe.Domain.Apartments;
using BookMe.Domain.Shared;

namespace BookMe.Domain.Bookings;
public class PricingService
{
    public PricingDetails CalculatePrice(Apartment apartment, DateRange period)
    {
        var currency = apartment.Price.Currency;

        var priceForPeriod = new Money(apartment.Price.Amount * period.LengthInDays, currency);

        decimal percentageUpCharge = 0;
        foreach (var apartmentAmenity in apartment.Amenities)
        {
            percentageUpCharge += apartmentAmenity switch
            {
                Amenity.GardenView or Amenity.MountainView => 0.5m,
                Amenity.AirConditioner or Amenity.Parking => 0.01m,
                _ => 0
            };
        }

        var amenitiesUpCharge = Money.Zero(currency);
        if (percentageUpCharge > 0)
        {
            amenitiesUpCharge = new Money(priceForPeriod.Amount * percentageUpCharge, currency);
        }

        var totalPrice = Money.Zero(currency);

        totalPrice += priceForPeriod;

        if (!apartment.CleaningFee.IsZero())
        {
            totalPrice += apartment.CleaningFee;
        }

        totalPrice += amenitiesUpCharge;

        return new PricingDetails(priceForPeriod, apartment.CleaningFee, amenitiesUpCharge, totalPrice);
    }
}
