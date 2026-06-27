using System.ComponentModel.DataAnnotations;

namespace TaskManager.API.Models.Tasks;

public class TaskDtoUpdate : IValidatableObject
{
    [MaxLength(200, ErrorMessage = "Title must be at most 200 characters long")]
    public string? Title { get; set; }

    [MaxLength(500, ErrorMessage = "Description must be at most 500 characters long")]
    public string? Description { get; set; }

    public Priority? Priority { get; set; }
    public Status? Status { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (Priority.HasValue && !Enum.IsDefined(Priority.Value))
        {
            yield return new ValidationResult(
                $"Invalid priority value: {Priority}.",
                [nameof(Priority)]);
        }
        if (Status.HasValue && !Enum.IsDefined(Status.Value))
        {
            yield return new ValidationResult(
                $"Invalid status value: {Status}.",
                [nameof(Status)]);
        }
        bool notUpdated = true;
        foreach (var property in typeof(TaskDtoUpdate).GetProperties())
            if (property.GetValue(this) is not null)
            {
                notUpdated = false;
                break;
            }
        if (notUpdated)
            yield return new ValidationResult(
                "At least one property must be provided for update.",
                [nameof(TaskDtoUpdate)]);
    }
}
