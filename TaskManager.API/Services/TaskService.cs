using TaskManager.API.Data.Repositories;
using TaskManager.API.Models.Tasks;

namespace TaskManager.API.Services;

public class TaskService(TaskRepository taskRepository)
{
    public async Task<IEnumerable<TaskDtoInfo>> GetAllTasksAsync()
    {
        var tasks = await taskRepository.GetAllTasksAsync();
        return tasks.Select(TaskMapper.ToTaskDtoInfo);
    }
    public async Task<TaskDtoInfo> GetTaskByIdAsync(int id)
    {

        var task = await taskRepository.GetTaskByIdAsync(id);
        return TaskMapper.ToTaskDtoInfo(task);
    }
    public async Task<TaskDtoInfo> CreateTaskAsync(TaskDtoCreate taskDtoCreate)
    {
        var task = await taskRepository.CreateTaskAsync(TaskMapper.ToTask(taskDtoCreate));
        return TaskMapper.ToTaskDtoInfo(task);
    }
    public async Task<TaskDtoInfo> UpdateTaskAsync(int id, TaskDtoUpdate taskDtoUpdate)
    {
        var existingTask = await taskRepository.GetTaskByIdAsync(id);
        existingTask.Update(taskDtoUpdate);
        var updatedTask = await taskRepository.UpdateTaskAsync(id, existingTask);
        return TaskMapper.ToTaskDtoInfo(updatedTask);
    }
    public async System.Threading.Tasks.Task DeleteTaskAsync(int id)
    {
        await taskRepository.DeleteTaskAsync(id);
    }
}
