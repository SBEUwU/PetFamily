using CSharpFunctionalExtensions;
using PetFamily.Domain.Species;

namespace PetFamily.Domain.Pet;

public record SpeciesBreedIds 
{
    private SpeciesBreedIds (SpeciesId speciesId, BreedId breedId) 
    {
        SpeciesId = speciesId; 
        BreedId = breedId; 

    }
    
    public SpeciesId SpeciesId { get; }
    public BreedId BreedId { get; } 
    
    public static Result<SpeciesBreedIds> Create(SpeciesId speciesId, BreedId breedId)
    {
        if (speciesId == null)
            return Result.Failure<SpeciesBreedIds>("SpeciesId cannot be null");
        if (breedId == null)
            return Result.Failure<SpeciesBreedIds>("BreedId cannot be null");

        return Result.Success(new SpeciesBreedIds(speciesId, breedId));
    }
}