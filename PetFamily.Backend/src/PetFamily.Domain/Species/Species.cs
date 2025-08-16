using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Species;

public class Species : PetFamily.Domain.Shared.Entity<SpeciesId>
{
    private readonly List<Breed> _breeds = [];
    
    private Species(SpeciesId id) : base(id)
    {
        // EF Core
    }
    
    private Species(SpeciesId speciesId, string name) : base(speciesId)
    {
        Name = name;
    }
    
    public string Name { get; private set; } = default!;
    
    public IReadOnlyList<Breed> Breeds => _breeds;
    
    public void AddBreed(Breed breed)
    {
        _breeds.Add(breed);
    }

    public static Result<Species> Create(SpeciesId speciesId, string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            return Result.Failure<Species>("Name cannot be empty");

        var species = new Species(speciesId, name);
        
        return Result.Success(species);
    }
}