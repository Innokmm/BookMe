using BookMe.Domain.Abstractions;

namespace BookMe.Domain.Bookings.Events;

public record BookingCancelledDomainEvent(Guid BookingId) : IDomainEvent;