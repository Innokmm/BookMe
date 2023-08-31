using BookMe.Domain.Shared;

namespace BookMe.Domain.Bookings;
public record PricingDetails(
    Money PriceForPeriod,
    Money CleaningFee,
    Money AmenitiesUpCharge,
    Money TotalPrice);