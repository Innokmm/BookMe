using BookMe.Domain.Abstractions;

namespace BookMe.Domain.Bookings.Events;

public record BookingReservedDomainEvent(Guid BookingId) : IDomainEvent;