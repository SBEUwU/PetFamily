using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Species;

public class Breed : PetFamily.Domain.Shared.Entity<BreedId>
{
    private Breed(BreedId id) : base(id)
    {
        // EF Core
    }
    
    private Breed(BreedId breedId, string name) : base(breedId)
    {
        Name = name;
    }
    
    public string Name { get; private set; } = default!;
    
    public static Result<Breed> Create(BreedId breedId, string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            return Result.Failure<Breed>("Name cannot be empty");

        var breed = new Breed(breedId, name);
        
        return Result.Success(breed);
    }
}