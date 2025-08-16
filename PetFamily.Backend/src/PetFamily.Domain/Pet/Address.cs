using CSharpFunctionalExtensions;
using PetFamily.Domain.Shared;

namespace PetFamily.Domain.Pet;

public record Address
{
    private Address(string street, string city, string zipCode)
    {
        Street = street;
        City = city;
        ZipCode = zipCode;
    }
    
    public string Street { get; }
    public string City { get; }
    public string ZipCode { get; }

    public static Result<Address, Error> Create(string street, string city, string zipCode)
    {
        if (string.IsNullOrWhiteSpace(street))
            return Errors.General.ValueIsInvalid("street");
        if (string.IsNullOrWhiteSpace(city))
            return Errors.General.ValueIsInvalid("city");
        if (string.IsNullOrWhiteSpace(zipCode))
            return Errors.General.ValueIsInvalid("zip code");
        
        var address = new Address(street, city, zipCode);

        return address;
    }
}