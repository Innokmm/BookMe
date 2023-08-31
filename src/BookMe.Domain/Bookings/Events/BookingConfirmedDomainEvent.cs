using BookMe.Domain.Abstractions;

namespace BookMe.Domain.Bookings.Events;

public record BookingConfirmedDomainEvent(Guid BookingId) : IDomainEvent;