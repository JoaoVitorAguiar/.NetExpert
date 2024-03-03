using DevFreela.Core.Entities.Projects;
using DevFreela.Core.Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Infrastructure.Persistense;

public class DevFreelaDbContext : DbContext
{
    public DbSet<Project> Projects { get; private set; }
    public DbSet<User> Users { get; private set; }
    public DbSet<Skill> Skills { get; private set; }
    public DbSet<UserSkill> UserSkills { get; private set; }
    public DbSet<ProjectComment> ProjectComment { get; private set; }

    public DevFreelaDbContext(DbContextOptions<DevFreelaDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // ----------------- Project ----------------- 
        modelBuilder.Entity<Project>()
            .HasKey(p => p.Id);

        // Um projeto tem um freelancer e um freelancer tem vários Freelanceprojetos com chave estrangeira IdFreelancer
        modelBuilder.Entity<Project>()
            .HasOne(p => p.Freelancer)
            .WithMany(f => f.FreelanceProject)
            .HasForeignKey(p => p.FreelancerId)
            .OnDelete(DeleteBehavior.Restrict); // Comportamento

        modelBuilder.Entity<Project>()
            .HasOne(p => p.Client)
            .WithMany(c => c.OwnedProject)
            .HasForeignKey(p => p.ClientId)
            .OnDelete(DeleteBehavior.Restrict); // Comportamento

        // ------------------------------------------


        // ----------------- User ----------------- 
        modelBuilder.Entity<User>()
            .HasKey(u => u.Id);

        modelBuilder.Entity<User>()
            .HasMany(u => u.Skills)
            .WithOne()
            .HasForeignKey(u => u.SkillId)
            .OnDelete(DeleteBehavior.Restrict);

        // ---------------------------------------- 


        modelBuilder.Entity<Skill>()
            .HasKey(s => s.Id);

         modelBuilder.Entity<UserSkill>()
            .HasKey(u => u.Id);

        // ----------------- ProjectComments ----------------- 

        modelBuilder.Entity<ProjectComment>()
            .HasKey(p => p.Id);
        modelBuilder.Entity<ProjectComment>()
            .HasOne(p => p.Project)
            .WithMany(p => p.Comments)
            .HasForeignKey(p => p.ProjectId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<ProjectComment>()
            .HasOne(p => p.User)
            .WithMany(p => p.Comments)
            .HasForeignKey(p => p.UserId)
            .OnDelete(DeleteBehavior.Restrict);


    }
}
