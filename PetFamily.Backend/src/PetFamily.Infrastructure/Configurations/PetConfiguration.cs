
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetFamily.Domain.Pet;
using PetFamily.Domain.Shared;
using PetFamily.Domain.Species;
using PetFamily.Domain.Volonteer;

public class PetConfiguration : IEntityTypeConfiguration<Pet>
{
    public void Configure(EntityTypeBuilder<Pet> builder)
    {
        builder.ToTable("pet");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id)
            .HasConversion(
                id => id.Value,
                value => PetId.Create(value));

        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH);

        builder.ComplexProperty(p => p.SpeciesBreedIds, pb =>
        {
            pb.Property(vhd => vhd.SpeciesId)
                .IsRequired()
                .HasConversion(
                    id => id.Value,
                    value => SpeciesId.Create(value))
                .HasColumnName("species_id");
            
            pb.Property(vhd => vhd.BreedId)
                .IsRequired()
                .HasConversion(
                    id => id.Value,
                    value => BreedId.Create(value))
                .HasColumnName("breed_id");
            
        });
        
        builder.Property(v => v.Description)
            .IsRequired()
            .HasMaxLength(Constants.MAX_HIGH_TEXT_LENGTH);

        builder.Property(v => v.Color)
            .IsRequired()
            .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH);

        builder.Property(v => v.HealthInfo)
            .IsRequired()
            .HasMaxLength(Constants.MAX_HIGH_TEXT_LENGTH);

        builder.ComplexProperty(p => p.Address, pb =>
        {
            pb.Property(vhd => vhd.Street)
                .IsRequired()
                .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH)
                .HasColumnName("street");
            
            pb.Property(vhd => vhd.City)
                .IsRequired()
                .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH)
                .HasColumnName("city");
            
            pb.Property(vhd => vhd.ZipCode)
                .IsRequired()
                .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH)
                .HasColumnName("zipcode");
            
        });

        builder.Property(v => v.Weight)
            .IsRequired();

        builder.Property(v => v.Height)
            .IsRequired();
        
        builder.Property(v => v.PhoneNumber)
            .IsRequired()
            .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH);
        
        builder.Property(v => v.Castrate)
            .IsRequired();
        
        builder.Property(v => v.BirthDate)
            .IsRequired();
        
        builder.Property(v => v.Vaccination)
            .IsRequired();
        
        builder.ComplexProperty(p => p.Status, pb =>
        {
            pb.Property(vhd => vhd.Value)
                .IsRequired()
                .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH)
                .HasColumnName("status");
        });
        
        builder.OwnsOne(p => p.PetHelpDetail, pb =>
        {
            pb.ToJson();
            
            pb.Property(phd => phd.Name)
                .IsRequired()
                .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH);
            
            pb.Property(phd => phd.Description)
                .IsRequired()
                .HasMaxLength(Constants.MAX_HIGH_TEXT_LENGTH);
            
            pb.Property(phd => phd.Info)
                .IsRequired()
                .HasMaxLength(Constants.MAX_HIGH_TEXT_LENGTH);
        });
        

        builder.Property(v => v.CreateDate)
            .IsRequired();

        builder.OwnsOne(p => p.Details, pd =>
        {
            pd.ToJson();

            pd.OwnsMany(d => d.Photos, dp =>
            {
                dp.Property(s => s.PathToPhoto)
                    .IsRequired()
                    .HasMaxLength(Constants.MAX_MEDIUM_TEXT_LENGTH);
            });
        });
    }
}