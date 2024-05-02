using BookMe.Domain.Abstractions;

namespace BookMe.Domain.Reviews.Events;

public sealed record ReviewCreatedDomainEvent(Guid ReviewId) : IDomainEvent;