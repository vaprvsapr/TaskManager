using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace TaskManager.API.Data.Configurations;

public class TaskConfiguration : IEntityTypeConfiguration<Models.Tasks.Task>
{
    public void Configure(EntityTypeBuilder<Models.Tasks.Task> builder)
    {
        builder.HasKey(t => t.Id);

        builder.Property(t => t.Title)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(t => t.Description)
            .IsRequired()
            .HasMaxLength(500);

        builder.Property(t => t.Priority)
            .IsRequired();

        builder.Property(t => t.Status)
            .IsRequired();

        builder.HasOne(t => t.AssignedToUser)
            .WithMany(u => u.AssignedToTasks)
            .HasForeignKey(t => t.AssignedToUserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(t => t.AssignedByUser)
            .WithMany(u => u.AssignedByTasks)
            .HasForeignKey(t => t.AssignedByUserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(t => t.CreatedAt)
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder.Property(t => t.ModifiedAt);

        builder.ToTable(t =>
            t.HasCheckConstraint("CK_Task_ModifiedAt", "\"ModifiedAt\" >= \"CreatedAt\"")
        );
    }
}
