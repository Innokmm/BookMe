using BookMe.Domain.Abstractions;
using BookMe.Domain.Shared;

namespace BookMe.Domain.Apartments;

public sealed class Apartment : Entity
{
    public Apartment(Guid id, 
        Name name, 
        Description description, 
        Address address, 
        decimal price, 
        decimal cleaningFee, 
        Currency currency,
        DateTime? lastBookedOnUtc,
        List<Amenity> amenities) 
        : base(id)
    {
        Name = name;
        Description = description;
        Address = address;
        Price = new Money(price, currency);
        CleaningFee = new Money(cleaningFee, currency);
        LastBookedOnUtc = lastBookedOnUtc;
        Amenities = amenities;
    }

    public Name Name { get; private set; }    
    public Description Description { get; private set; }
    public Address Address { get; private set; }
    public Money Price { get; private set; }
    public Money CleaningFee { get; private set; }
    public DateTime? LastBookedOnUtc { get; internal set; }
    public List<Amenity> Amenities { get; private set; }
}
