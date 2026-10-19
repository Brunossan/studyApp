using ArtificialTeacherApi.Enums;
using ArtificialTeacherApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArtificialTeacherApi.Data.Configurations;

public class MemorizationTechniqueConfiguration : IEntityTypeConfiguration<MemorizationTechnique>
{
    public void Configure(EntityTypeBuilder<MemorizationTechnique> builder)
    {
        builder.ToTable("MemorizationTechniques");

        builder.HasKey(t => t.Id);

        builder.Property(t => t.Id)
            .HasDefaultValueSql("NEWID()");

        builder.Property(t => t.TechniqueType)
            .IsRequired()
            .HasMaxLength(50)
            .HasConversion<string>();

        builder.Property(t => t.Title)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(t => t.Description);

        builder.Property(t => t.GeneratedContent)
            .IsRequired();

        builder.Property(t => t.GenerationOrigin)
            .IsRequired()
            .HasMaxLength(30)
            .HasConversion<string>();

        builder.Property(t => t.IsFavorite)
            .IsRequired()
            .HasDefaultValue(false);

        builder.Property(t => t.CreatedAt)
            .IsRequired()
            .HasDefaultValueSql("GETUTCDATE()");

        builder.Property(t => t.UpdatedAt);
    }
}
