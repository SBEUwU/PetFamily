using CSharpFunctionalExtensions;
using PetFamily.Domain.Shared;

namespace PetFamily.Domain.Pet;

public record Status
{
    private Status(string value)
    {
        Value = value;
    }
    
    public string Value { get; }

    public static Result<Status, Error> Create(string value)
    {
        if (value != nameof(StatusValues.Adopted) && value != nameof(StatusValues.Available) && value != nameof(StatusValues.Recovering))
            return Errors.General.ValueIsInvalid("status");
        
        var status = new Status(value);

        return status;
    }
}

public enum StatusValues
{
    Adopted,
    Available,
    Recovering
}