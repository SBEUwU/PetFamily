using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Volonteer;

public record VolonteerHelpDetail
{
    private VolonteerHelpDetail(string name, string description, string info)
    {
        Name = name;
        Description = description;
        Info = info;
    }
    
    public string Name { get; }
    public string Description { get; }
    public string Info { get; }
    
    public static Result<VolonteerHelpDetail> Create(string name, string description, string info)
    {
        if (string.IsNullOrWhiteSpace(name))
            return Result.Failure<VolonteerHelpDetail>("Name cannot be empty");
        if (string.IsNullOrWhiteSpace(description))
            return Result.Failure<VolonteerHelpDetail>("Description cannot be empty");
        if (string.IsNullOrWhiteSpace(info))
            return Result.Failure<VolonteerHelpDetail>("Info cannot be empty");

        var helpDetail = new VolonteerHelpDetail(name, description, info);
        
        return Result.Success(helpDetail);
    }
}