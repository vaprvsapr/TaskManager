namespace TaskManager.API.Models.Tasks;

public static class TaskMapper
{
    public static Task ToTask(TaskDtoCreate taskCreateDto)
    {
        return new Task
        {
            Title = taskCreateDto.Title,
            Description = taskCreateDto.Description,
            Priority = taskCreateDto.Priority,
            AssignedToUserId = taskCreateDto.AssignedToUserId,
            AssignedByUserId = taskCreateDto.AssignedByUserId
        };
    }

    public static TaskDtoInfo ToTaskDtoInfo(Task task)
    {
        return new TaskDtoInfo
        {
            Id = task.Id,
            Title = task.Title,
            Description = task.Description,
            Priority = task.Priority.ToString(),
            Status = task.Status.ToString(),
            AssignedToUserId = task.AssignedToUserId,
            AssignedByUserId = task.AssignedByUserId,
            CreatedAt = task.CreatedAt,
            ModifiedAt = task.ModifiedAt
        };
    }
}
