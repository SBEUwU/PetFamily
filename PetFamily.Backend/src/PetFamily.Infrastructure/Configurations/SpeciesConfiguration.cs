using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetFamily.Domain.Species;

namespace PetFamily.Infrastructure;

public class SpeciesConfiguration : IEntityTypeConfiguration<Species>
{
    public void Configure(EntityTypeBuilder<Species> builder)
    {
        builder.ToTable("species");
        
        builder.HasKey(s => s.Id);
        
        builder.Property(s => s.Id)
            .HasConversion(
                id => id.Value,
                value => SpeciesId.Create(value));
        
        builder.Property(s => s.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.HasMany(s => s.Breeds)
            .WithOne()
            .HasForeignKey("species_id");

    }
}