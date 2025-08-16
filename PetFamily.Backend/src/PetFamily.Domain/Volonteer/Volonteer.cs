using CSharpFunctionalExtensions;
using PetFamily.Domain.Shared;

namespace PetFamily.Domain.Volonteer;

public class Volonteer : Shared.Entity<VolonteerId>
{
    private readonly List<SocialMedia> _socialMedias = [];
    private readonly List<Pet.Pet> _pets = [];
    
    private Volonteer(VolonteerId id) : base(id)
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
    
    public int AdoptedPetCount => Pets.Count(p => p.Status.Value == "Adopted");
    
    public int AvailablePetCount => Pets.Count(p => p.Status.Value == "Available");
    
    public int RecoveringPetCount => Pets.Count(p => p.Status.Value == "Recovering");
    
    public string PhoneNumber { get; private set; } = default!;
    
    public VolonteerHelpDetail VolonteerHelpDetail { get; private set; } = default!;

    public IReadOnlyList<Pet.Pet> Pets => _pets;
    
    public VolonteerDetails Details { get; private set; } = default!;
    
    public void AddSocialMedia(SocialMedia socialMedia)
    {
        Details.SocialMedias.Add(socialMedia);
    }
    
    public void AddPet(Pet.Pet pet)
    {
        _pets.Add(pet);
    }
    
    public static Result<Volonteer, Error> Create(VolonteerId volonteerId, string fullName, string email, string description, int yearsExperience, string phoneNumber, VolonteerHelpDetail volonteerHelpDetail)
    {
        if (string.IsNullOrWhiteSpace(fullName))
            return Errors.General.ValueIsInvalid("full name");
        if (string.IsNullOrWhiteSpace(email)) 
            return Errors.General.ValueIsInvalid("email");
        if (string.IsNullOrWhiteSpace(description))
            return Errors.General.ValueIsInvalid("description");
        if (yearsExperience < 0)
            return Errors.General.ValueIsInvalid("years experience");
        if (string.IsNullOrWhiteSpace(phoneNumber))
            return Errors.General.ValueIsInvalid("phone number");
        
        var volonteer = new Volonteer(volonteerId, fullName, email, description, yearsExperience, phoneNumber, volonteerHelpDetail);
        
        return volonteer;
    }
}