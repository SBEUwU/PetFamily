using CSharpFunctionalExtensions;
using PetFamily.Domain.Shared;
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
    
    public static Result<SpeciesBreedIds, Error> Create(SpeciesId speciesId, BreedId breedId)
    {
        if (speciesId == null)
            return Errors.General.ValueIsInvalid("species id");
        if (breedId == null)
            return Errors.General.ValueIsInvalid("breed id");

        return new SpeciesBreedIds(speciesId, breedId);
    }
}