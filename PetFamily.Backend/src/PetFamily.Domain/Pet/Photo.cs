using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Pet;

public record Photo
{
    private Photo(string pathToPhoto)
    {
        PathToPhoto = pathToPhoto;
    }
    
    public string PathToPhoto { get; }
    
    public static Result<Photo> Create(string pathToPhoto)
    {
        if (string.IsNullOrWhiteSpace(pathToPhoto))
            return Result.Failure<Photo>("Path to photo cannot be empty");

        var photo = new Photo(pathToPhoto);
        
        return Result.Success(photo);
    }
}