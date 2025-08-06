using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Volonteer;

public record SocialMedia
{
    private SocialMedia(string name, string link)
    {
        Name = name;
        Link = link;
    }
    
    public string Name { get; }
    public string Link { get; }
    
    public static Result<SocialMedia> Create(string name, string link)
    {
        if (string.IsNullOrWhiteSpace(name))
            return Result.Failure<SocialMedia>("Name cannot be empty");
        if (string.IsNullOrWhiteSpace(link))
            return Result.Failure<SocialMedia>("Link cannot be empty");

        var socialMedia = new SocialMedia(name, link);
        
        return Result.Success(socialMedia);
    }
}