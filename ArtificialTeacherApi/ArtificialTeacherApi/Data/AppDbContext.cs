using ArtificialTeacherApi.Data.Configurations;
using ArtificialTeacherApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ArtificialTeacherApi.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Content> Contents => Set<Content>();
    public DbSet<MemorizationTechnique> MemorizationTechniques => Set<MemorizationTechnique>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ContentConfiguration());
        modelBuilder.ApplyConfiguration(new MemorizationTechniqueConfiguration());
    }
}
