using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Pet;

public record Status
{
    private Status(string value)
    {
        Value = value;
    }
    
    public string Value { get; }

    public static Result<Status> Create(string value)
    {
        if (value != "Adopted" && value != "Available" && value != "Recovering")
            return Result.Failure<Status>("Status cannot be another than Adopted, Available, Recovering");
        
        var status = new Status(value);

        return status;
    }
}