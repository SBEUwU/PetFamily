using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Pet;

public record PetHelpDetail
{
    private PetHelpDetail(string name, string description, string info)
    {
        Name = name;
        Description = description;
        Info = info;
    }
    
    public string Name { get; }
    public string Description { get; }
    public string Info { get; }
    
    public static Result<PetHelpDetail> Create(string name, string description, string info)
    {
        if (string.IsNullOrWhiteSpace(name))
            return Result.Failure<PetHelpDetail>("Name cannot be empty");
        if (string.IsNullOrWhiteSpace(description))
            return Result.Failure<PetHelpDetail>("Description cannot be empty");
        if (string.IsNullOrWhiteSpace(info))
            return Result.Failure<PetHelpDetail>("Info cannot be empty");

        var petHelpDetail = new PetHelpDetail(name, description, info);
        
        return Result.Success(petHelpDetail);
    }
}