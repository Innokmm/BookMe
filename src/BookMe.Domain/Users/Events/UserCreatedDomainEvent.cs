using BookMe.Domain.Abstractions;

namespace BookMe.Domain.Users.Events;

public record UserCreatedDomainEvent(Guid UserId) : IDomainEvent;