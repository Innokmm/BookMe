using BookMe.Domain.Abstractions;
using BookMe.Domain.Users.Events;

namespace BookMe.Domain.Users;

public class User : Entity
{
    private User(Guid id, 
        FirstName firstName, 
        LastName lastName, 
        Email email) 
        : base(id)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
    }

    public FirstName FirstName { get; private set; }
    public LastName LastName { get; private set; }
    public Email Email { get; private set; }

    public static User Create(
        FirstName firstName,
        LastName lastName,
        Email email)
    {
        var user = new User(new Guid(), firstName, lastName, email);

        user.RaiseDomainEvent(new UserCreatedDomainEvent(user.Id));

        return user;
    }
}