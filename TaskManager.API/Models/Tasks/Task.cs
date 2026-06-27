using TaskManager.API.Models.Users;
namespace TaskManager.API.Models.Tasks;

public class Task
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public required string Description { get; set; }
    public Priority Priority { get; set; } = Priority.Normal;
    public Status Status { get; set; } = Status.Pending;
    public required int AssignedToUserId { get; set; }
    public required int AssignedByUserId { get; set; }
    public User AssignedToUser { get; set; } = null!;
    public User AssignedByUser { get; set; } = null!;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? ModifiedAt { get; set; }
}
