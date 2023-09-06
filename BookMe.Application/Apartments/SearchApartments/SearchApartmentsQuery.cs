using BookMe.Application.Abstractions.Messaging;

namespace BookMe.Application.Apartments.SearchApartments;

public record SearchApartmentsQuery(DateOnly StartDate) : IQuery<IReadOnlyList<ApartmentResponse>>;