using System.ComponentModel.DataAnnotations;
namespace TaskManager.API.Models.Users;

public class UserDtoCreate
{
    [Required(ErrorMessage = "Name is required")]
    public string Name { get; set; } = null!;
}
