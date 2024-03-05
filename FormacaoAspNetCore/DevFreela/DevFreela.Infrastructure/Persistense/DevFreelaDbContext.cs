using DevFreela.Core.Entities.Projects;
using DevFreela.Core.Entities.Users;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

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
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());


    }
}
