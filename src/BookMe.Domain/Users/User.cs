using BookMe.Domain.Abstractions;

namespace BookMe.Domain.Users;

public class User : Entity
{
    public User(Guid id, 
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

}