using BookMe.Application.Abstractions.Messaging;

namespace BookMe.Application.Apartments.SearchApartments;

public record SearchApartmentsQuery(DateOnly StartDate, DateOnly EndDate) : IQuery<IReadOnlyList<ApartmentResponse>>;