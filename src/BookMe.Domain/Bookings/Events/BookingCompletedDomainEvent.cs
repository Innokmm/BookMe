using BookMe.Domain.Abstractions;

namespace BookMe.Domain.Bookings.Events;

public record BookingCompletedDomainEvent(Guid BookingId) : IDomainEvent;