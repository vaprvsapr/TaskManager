using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManager.API.Models.Users;


namespace TaskManager.API.Data.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);

        builder.Property(u => u.Name)
            .HasMaxLength(100)
            .IsRequired();

        builder.HasMany(u => u.AssignedToTasks)
            .WithOne(t => t.AssignedToUser);

        builder.HasMany(u => u.AssignedByTasks)
            .WithOne(t => t.AssignedByUser);
    }
}
