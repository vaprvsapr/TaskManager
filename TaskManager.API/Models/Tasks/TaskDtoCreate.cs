using System.ComponentModel.DataAnnotations;
namespace TaskManager.API.Models.Tasks;

public class TaskDtoCreate
{
    [Required(ErrorMessage = "Title is required")]
    public string Title { get; set; } = null!;

    [Required(ErrorMessage = "Description is required")]
    public string Description { get; set; } = null!;
    public Priority Priority { get; set; } = Priority.Normal;

    [Required(ErrorMessage = "AssignedToUserId is required")]
    public int AssignedToUserId { get; set; }

    [Required(ErrorMessage = "AssignedByUserId is required")]
    public int AssignedByUserId { get; set; }
}
