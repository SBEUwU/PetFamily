using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Volonteer;

public class Volonteer : Shared.Entity<VolonteerId>
{
    private readonly List<SocialMedia> _socialMedias = [];
    private readonly List<Pet.Pet> _pets = [];
    
    private Volonteer(VolonteerId volonteerId) : base(volonteerId)
    {
        // EF Core
    }
    
    private Volonteer(VolonteerId volonteerId, string fullName, string email, string description, int yearsExperience, string phoneNumber, VolonteerHelpDetail volonteerHelpDetail) : base(volonteerId)
    {
        FullName = fullName;
        Email = email;
        Description = description;
        YearsExperience = yearsExperience;
        PhoneNumber = phoneNumber;
        VolonteerHelpDetail = volonteerHelpDetail;
    }
    
    public string FullName { get; private set; } = default!;
    
    public string Email { get; private set; } = default!;
    
    public string Description { get; private set; } = default!;
    
    public int YearsExperience { get; private set; } = default!;
    
    public int AdoptedPetCount => Pets.Count(p => p.Status == "Adopted");
    
    public int AvailablePetCount => Pets.Count(p => p.Status == "Available");
    
    public int RecoveringPetCount => Pets.Count(p => p.Status == "Recovering");
    
    public string PhoneNumber { get; private set; } = default!;

    public IReadOnlyList<SocialMedia> SocialMedias => _socialMedias;
    
    public VolonteerHelpDetail VolonteerHelpDetail { get; private set; } = default!;

    public IReadOnlyList<Pet.Pet> Pets => _pets;
    
    public void AddSocialMedia(SocialMedia socialMedia)
    {
        _socialMedias.Add(socialMedia);
    }
    
    public static Result<Volonteer> Create(VolonteerId volonteerId, string fullName, string email, string description, int yearsExperience, string phoneNumber, VolonteerHelpDetail volonteerHelpDetail)
    {
        if (string.IsNullOrWhiteSpace(fullName))
            return Result.Failure<Volonteer>("Full name cannot be empty");
        if (string.IsNullOrWhiteSpace(email))
            return Result.Failure<Volonteer>("Email cannot be empty");
        if (string.IsNullOrWhiteSpace(description))
            return Result.Failure<Volonteer>("Description cannot be empty");
        if (yearsExperience >= 0)
            return Result.Failure<Volonteer>("YearsExperience cannot be lower than 0");
        if (string.IsNullOrWhiteSpace(phoneNumber))
            return Result.Failure<Volonteer>("Phone number cannot be empty");
        
        var volonteer = new Volonteer(volonteerId, fullName, email, description, yearsExperience, phoneNumber, volonteerHelpDetail);
        
        return Result.Success(volonteer);
    }
}