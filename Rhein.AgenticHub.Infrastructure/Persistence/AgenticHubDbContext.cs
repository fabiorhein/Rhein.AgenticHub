using Microsoft.EntityFrameworkCore;
using Rhein.AgenticHub.Domain.Entities;

namespace Rhein.AgenticHub.Infrastructure.Persistence;

public class AgenticHubDbContext : DbContext
{
    public AgenticHubDbContext(DbContextOptions<AgenticHubDbContext> options) : base(options) {}
    
    public DbSet<Agent> Agents { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Agent>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(200);
            
            entity.HasMany(a => a.AssignedEvents)
                .WithOne()
                .HasForeignKey(a => a.AssignedAgentId)
                .OnDelete(DeleteBehavior.Cascade);
            
            entity.Metadata.FindNavigation(nameof(Agent.AssignedEvents))
                ?.SetPropertyAccessMode(PropertyAccessMode.Field);
        });

        modelBuilder.Entity<Event>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Title).IsRequired().HasMaxLength(200);
            entity.Property(e => e.Status).IsRequired().HasMaxLength(50);
        });
    }
}