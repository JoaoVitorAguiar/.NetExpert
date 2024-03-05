using DevFreela.Core.Entities.Projects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Infrastructure.Persistense.Configurations;

public class ProjectConfigurations : IEntityTypeConfiguration<Project>
{
    public void Configure(EntityTypeBuilder<Project> builder)
    {
        builder.HasKey(p => p.Id);

        builder
            .HasOne(p => p.Freelancer)
            .WithMany(f => f.FreelanceProject)
            .HasForeignKey(p => p.FreelancerId)
            .OnDelete(DeleteBehavior.Restrict); 

        builder
            .HasOne(p => p.Client)
            .WithMany(c => c.OwnedProject)
            .HasForeignKey(p => p.ClientId)
            .OnDelete(DeleteBehavior.Restrict); 
    }
}
