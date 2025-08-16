using CSharpFunctionalExtensions;
using PetFamily.Domain.Shared;

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
    
    public static Result<SocialMedia, Error> Create(string name, string link)
    {
        if (string.IsNullOrWhiteSpace(name))
            return Errors.General.ValueIsInvalid("name");
        if (string.IsNullOrWhiteSpace(link))
            return Errors.General.ValueIsInvalid("link");

        var socialMedia = new SocialMedia(name, link);
        
        return socialMedia;
    }
}