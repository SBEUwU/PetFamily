using CSharpFunctionalExtensions;
using PetFamily.Domain.Shared;

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
    
    public static Result<PetHelpDetail, Error> Create(string name, string description, string info)
    {
        if (string.IsNullOrWhiteSpace(name))
            return Errors.General.ValueIsInvalid("name");
        if (string.IsNullOrWhiteSpace(description))
            return Errors.General.ValueIsInvalid("description");
        if (string.IsNullOrWhiteSpace(info))
            return Errors.General.ValueIsInvalid("info");

        var petHelpDetail = new PetHelpDetail(name, description, info);
        
        return petHelpDetail;
    }
}