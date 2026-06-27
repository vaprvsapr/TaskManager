namespace TaskManager.API.Models.Tasks;

public class TaskDtoInfo
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public required string Description { get; set; }
    public string Priority { get; set; } = null!;
    public string Status { get; set; } = null!;
    public required int AssignedToUserId { get; set; }
    public required int AssignedByUserId { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? ModifiedAt { get; set; }
}
