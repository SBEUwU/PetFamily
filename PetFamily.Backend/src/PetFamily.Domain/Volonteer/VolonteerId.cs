namespace PetFamily.Domain.Volonteer;

public record VolonteerId
{
    private VolonteerId(Guid value)
    {
        Value = value;
    }
    
    public Guid Value { get; }

    public static VolonteerId NewPetId() => new(Guid.NewGuid());
    
    public static VolonteerId Empty() => new(Guid.Empty);

    public static VolonteerId Create(Guid id) => new(id);
}