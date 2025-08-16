using CSharpFunctionalExtensions;
using PetFamily.Domain.Shared;

namespace PetFamily.Domain.Pet;

public class Pet : Shared.Entity<PetId>
{
    
    private Pet(PetId id) : base(id)
    {
        // EF Core
    }
    
    private Pet(PetId petId, string name, SpeciesBreedIds speciesBreedIds, string description,
        string color, string healthInfo, Address address, float weight, float height, string phoneNumber, bool castrate,
        DateTime birthDate, bool vaccination, Status status, PetHelpDetail petHelpDetail, DateTime createDate) : base(petId)
    {
        Name = name;
        SpeciesBreedIds = speciesBreedIds;
        Description = description;
        Color = color;
        HealthInfo = healthInfo;
        Address = address;
        Weight = weight;
        Height = height;
        PhoneNumber = phoneNumber;
        Castrate = castrate;
        BirthDate = birthDate;
        Vaccination = vaccination;
        Status = status;
        PetHelpDetail = petHelpDetail;
        CreateDate = createDate;
    }
    
    public string Name { get; private set; } = default!;
    
    public SpeciesBreedIds SpeciesBreedIds { get; private set; } = default!;
    
    public string Description { get; private set; } = default!;
    
    public string Color { get; private set; } = default!;
    
    public string HealthInfo { get; private set; } = default!;
    
    public Address Address { get; private set; } = default!;
    
    public float Weight { get; private set; } = default!;
    
    public float Height { get; private set; } = default!;
    
    public string PhoneNumber { get; private set; } = default!;
    
    public bool Castrate { get; private set; } = default!;
    
    public DateTime BirthDate { get; private set; } = default!;
    
    public bool Vaccination { get; private set; } = default!;
    
    public Status Status { get; private set; } = default!;
    
    public PetHelpDetail PetHelpDetail { get; private set; } = default!;
    
    public DateTime CreateDate { get; private set; } = default!;
    
    public PetDetails Details { get; private set; } = default!;
    
    public void AddPhoto(Photo photo)
    {
        Details.Photos.Add(photo);
    }
    
    public static Result<Pet, Error> Create(PetId petId, string name, SpeciesBreedIds speciesBreedIds, string description,
        string color, string healthInfo, Address address, float weight, float height, string phoneNumber, bool castrate,
        DateTime birthDate, bool vaccination, Status status, PetHelpDetail petHelpDetail, DateTime createDate)
    {
        if (string.IsNullOrWhiteSpace(name))
            return Errors.General.ValueIsInvalid("name");
        if (string.IsNullOrWhiteSpace(description))
            return Errors.General.ValueIsInvalid("description");
        if (string.IsNullOrWhiteSpace(color))
            return Errors.General.ValueIsInvalid("color");
        if (string.IsNullOrWhiteSpace(healthInfo))
            return Errors.General.ValueIsInvalid("health info");
        if (weight < 0)
            return Errors.General.ValueIsInvalid("weight");
        if (height < 0)
            return Errors.General.ValueIsInvalid("height");
        if (string.IsNullOrWhiteSpace(phoneNumber))
            return Errors.General.ValueIsInvalid("phoneNumber");
        
        var pet = new Pet(petId, name, speciesBreedIds, description, color, healthInfo,
            address, weight, height, phoneNumber, castrate, birthDate, vaccination, status, petHelpDetail, createDate);
        
        return pet;
    }
}