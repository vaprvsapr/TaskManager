namespace TaskManager.API.Models.Users;

public static class UserMapper
{
    public static User ToUser(UserDtoCreate userDtoCreate)
    {
        return new User
        {
            Name = userDtoCreate.Name
        };
    }

    public static UserDtoInfo ToUserDtoInfo(User user)
    {
        return new UserDtoInfo
        {
            Id = user.Id,
            Name = user.Name,
            AssignedToTasks = [..user.AssignedToTasks.Select(t => t.Id)],
            AssignedByTasks = [..user.AssignedByTasks.Select(t => t.Id)]
        };
    }
}
