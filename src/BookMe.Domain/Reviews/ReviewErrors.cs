using BookMe.Domain.Abstractions;

namespace BookMe.Domain.Reviews;

public static class ReviewErrors
{
    public static readonly Error NotEligible = new(
        "Review.NotEligible",
        "The review is not eligible because the booking is not yet completed");
}