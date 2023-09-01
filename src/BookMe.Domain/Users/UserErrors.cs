using BookMe.Domain.Abstractions;

namespace BookMe.Domain.Users;

public static class UserErrors
{
    public static Error NotFound => new(
        "User.NotFound",
        "The user with the specified identifier was not found"
    );
}