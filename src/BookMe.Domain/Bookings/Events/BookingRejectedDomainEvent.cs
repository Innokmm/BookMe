using BookMe.Domain.Abstractions;

namespace BookMe.Domain.Bookings.Events;

public record BookingRejectedDomainEvent(Guid BookingId) : IDomainEvent;