namespace TaskManager.API.Models.Users;

public class UserDtoInfo
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public List<int> AssignedToTasks { get; set; } = [];
    public List<int> AssignedByTasks { get; set; } = [];
}
