namespace TaskManager.API.Models.Tasks;

public static class TaskUpdater
{
    public static void Update(this Task task, TaskDtoUpdate taskDtoUpdate)
    {
        task.Status = taskDtoUpdate.Status ?? task.Status;
        task.Priority = taskDtoUpdate.Priority ?? task.Priority;
        task.Title = taskDtoUpdate.Title ?? task.Title;
        task.Description = taskDtoUpdate.Description ?? task.Description;
        task.ModifiedAt = DateTime.UtcNow;
    }
}
