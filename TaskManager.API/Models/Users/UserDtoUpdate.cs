using System.ComponentModel.DataAnnotations;
namespace TaskManager.API.Models.Users;

public class UserDtoUpdate : IValidatableObject
{
    public string Name { get; set; } = null!;

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        bool notUpdated = true;
        foreach (var item in typeof(UserDtoUpdate).GetProperties())
            if (item.GetValue(this) is null)
            {
                notUpdated = false;
                break;
            }
        if (notUpdated)
            yield return new ValidationResult(
                "At least one field must be provided for update.",
                typeof(UserDtoUpdate).GetProperties().Select(p => p.Name));
    }
}
