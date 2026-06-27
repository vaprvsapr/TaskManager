namespace TaskManager.API.Models.Users;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public List<Tasks.Task> AssignedToTasks { get; set; } = [];
    public List<Tasks.Task> AssignedByTasks { get; set; } = [];
}
