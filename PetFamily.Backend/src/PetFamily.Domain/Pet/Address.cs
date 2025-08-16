using CSharpFunctionalExtensions;

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

    public static Result<Address> Create(string street, string city, string zipCode)
    {
        if (string.IsNullOrWhiteSpace(street))
            return Result.Failure<Address>("Street cannot be empty");
        if (string.IsNullOrWhiteSpace(city))
            return Result.Failure<Address>("City cannot be empty");
        if (string.IsNullOrWhiteSpace(zipCode))
            return Result.Failure<Address>("ZipCode cannot be empty");
        
        var address = new Address(street, city, zipCode);

        return address;
    }
}