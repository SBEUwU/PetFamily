using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Pet;

public class Pet : Shared.Entity<PetId>
{
    private readonly List<Photo> _photos = [];
    
    private Pet(PetId petId) : base(petId)
    {
        // EF Core
    }
    
    private Pet(PetId petId, string name, SpeciesBreedIds speciesBreedIds, string description,
        string color, string healthInfo, string address, float weight, float height, string phoneNumber, bool castrate,
        DateTime birthDate, bool vaccination, string status, PetHelpDetail petHelpDetail, DateTime createDate) : base(petId)
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
        Сastrate = castrate;
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
    
    public string Address { get; private set; } = default!;
    
    public float Weight { get; private set; } = default!;
    
    public float Height { get; private set; } = default!;
    
    public string PhoneNumber { get; private set; } = default!;
    
    public bool Сastrate { get; private set; } = default!;
    
    public DateTime BirthDate { get; private set; } = default!;
    
    public bool Vaccination { get; private set; } = default!;
    
    public string Status { get; private set; } = default!;
    
    public PetHelpDetail PetHelpDetail { get; private set; } = default!;
    
    public DateTime CreateDate { get; private set; } = default!;
    
    public IReadOnlyList<Photo> Photos => _photos;
    
    public void AddPhoto(Photo photo)
    {
        _photos.Add(photo);
    }
    
    public static Result<Pet> Create(PetId petId, string name, SpeciesBreedIds speciesBreedIds, string description,
        string color, string healthInfo, string address, float weight, float height, string phoneNumber, bool castrate,
        DateTime birthDate, bool vaccination, string status, PetHelpDetail petHelpDetail, DateTime createDate)
    {
        if (string.IsNullOrWhiteSpace(name))
            return Result.Failure<Pet>("Name cannot be empty");
        if (string.IsNullOrWhiteSpace(description))
            return Result.Failure<Pet>("Description cannot be empty");
        if (string.IsNullOrWhiteSpace(color))
            return Result.Failure<Pet>("Color cannot be empty");
        if (string.IsNullOrWhiteSpace(healthInfo))
            return Result.Failure<Pet>("HealthInfo cannot be empty");
        if (string.IsNullOrWhiteSpace(address))
            return Result.Failure<Pet>("Address cannot be empty");
        if (weight > 0)
            return Result.Failure<Pet>("Weight cannot be 0 or lower");
        if (height > 0)
            return Result.Failure<Pet>("Height cannot be 0 or lower");
        if (string.IsNullOrWhiteSpace(phoneNumber))
            return Result.Failure<Pet>("Phone number cannot be empty");
        if (string.IsNullOrWhiteSpace(status))
            return Result.Failure<Pet>("Status cannot be empty");
        
        var pet = new Pet(petId, name, speciesBreedIds, description, color, healthInfo,
            address, weight, height, phoneNumber, castrate, birthDate, vaccination, status, petHelpDetail, createDate);
        
        return Result.Success(pet);
    }
}