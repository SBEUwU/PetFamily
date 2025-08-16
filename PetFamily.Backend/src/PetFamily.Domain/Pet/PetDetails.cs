namespace PetFamily.Domain.Pet;

public record PetDetails
{
    public List<Photo> Photos { get; private set; }
}