namespace TaskManager.API.Data.Repositories;

public class TaskRepository(AppDbContext dbContext)
{
    public async Task<IQueryable<Models.Tasks.Task>> GetAllTasksAsync()
    {
        return dbContext.Tasks;
    }
    public async Task<Models.Tasks.Task> GetTaskByIdAsync(int id)
    {
        return await dbContext.Tasks.FindAsync(id) ??
            throw new KeyNotFoundException($"Task with Id {id} not found.");
    }
    public async Task<Models.Tasks.Task> CreateTaskAsync(Models.Tasks.Task task)
    {
        dbContext.Tasks.Add(task);
        await dbContext.SaveChangesAsync();
        return task;
    }
    public async Task<Models.Tasks.Task> UpdateTaskAsync(int id, Models.Tasks.Task updatedTask)
    {
        var existingTask = await GetTaskByIdAsync(id);
        existingTask.Title = updatedTask.Title;
        existingTask.Description = updatedTask.Description;
        existingTask.AssignedToUserId = updatedTask.AssignedToUserId;
        existingTask.AssignedByUserId = updatedTask.AssignedByUserId;
        await dbContext.SaveChangesAsync();
        return existingTask;
    }
    public async System.Threading.Tasks.Task DeleteTaskAsync(int id)
    {
        var task = await GetTaskByIdAsync(id);
        dbContext.Tasks.Remove(task);
        await dbContext.SaveChangesAsync();
    }
}
