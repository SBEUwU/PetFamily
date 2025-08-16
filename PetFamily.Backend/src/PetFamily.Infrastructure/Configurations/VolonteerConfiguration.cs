using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetFamily.Domain.Shared;
using PetFamily.Domain.Volonteer;

namespace PetFamily.Infrastructure;

public class VolonteerConfiguration : IEntityTypeConfiguration<Volonteer>
{
    public void Configure(EntityTypeBuilder<Volonteer> builder)
    {
        builder.ToTable("volonteer");
        
        builder.HasKey(v => v.Id);

        builder.Property(v => v.Id)
            .HasConversion(
                id => id.Value,
                value => VolonteerId.Create(value));
        
        builder.Property(v => v.FullName)
            .IsRequired()
            .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH);
        
        builder.Property(v => v.Email)
            .IsRequired()
            .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH);
        
        builder.Property(v => v.Description)
            .IsRequired()
            .HasMaxLength(Constants.MAX_HIGH_TEXT_LENGTH);

        builder.Property(v => v.YearsExperience)
            .IsRequired()
            .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH);
        
        builder.Property(v => v.PhoneNumber)
            .IsRequired()
            .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH);;

        builder.OwnsOne(v => v.Details, vd =>
        {
            vd.ToJson();

            vd.OwnsMany(d => d.SocialMedias, dsm =>
            {
                dsm.Property(s => s.Name)
                    .IsRequired()
                    .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH);
                dsm.Property(s => s.Link)
                    .IsRequired()
                    .HasMaxLength(Constants.MAX_MEDIUM_TEXT_LENGTH);
            });
        });

        builder.OwnsOne(v => v.VolonteerHelpDetail, vb =>
        {
            vb.ToJson();
            
            vb.Property(vhd => vhd.Name)
                .IsRequired()
                .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH);
            
            vb.Property(vhd => vhd.Description)
                .IsRequired()
                .HasMaxLength(Constants.MAX_HIGH_TEXT_LENGTH);
            
            vb.Property(vhd => vhd.Info)
                .IsRequired()
                .HasMaxLength(Constants.MAX_HIGH_TEXT_LENGTH);
        });
        
        builder.HasMany(v => v.Pets)
            .WithOne()
            .HasForeignKey("volonteer_id");
    }
}