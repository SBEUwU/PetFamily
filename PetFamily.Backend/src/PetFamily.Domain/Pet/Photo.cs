using CSharpFunctionalExtensions;
using PetFamily.Domain.Shared;

namespace PetFamily.Domain.Pet;

public record Photo
{
    private Photo(string pathToPhoto)
    {
        PathToPhoto = pathToPhoto;
    }
    
    public string PathToPhoto { get; }
    
    public static Result<Photo, Error> Create(string pathToPhoto)
    {
        if (string.IsNullOrWhiteSpace(pathToPhoto))
            return Errors.General.ValueIsInvalid("path to photo");

        var photo = new Photo(pathToPhoto);
        
        return photo;
    }
}