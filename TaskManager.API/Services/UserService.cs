using TaskManager.API.Data.Repositories;
using TaskManager.API.Models.Users;
namespace TaskManager.API.Services;

public class UserService(UserRepository userRepository)
{
    public async Task<IEnumerable<UserDtoInfo>> GetAllUsersAsync()
    {
        var users = await userRepository.GetAllUsersAsync();
        return users.Select(UserMapper.ToUserDtoInfo);
    }
    public async Task<UserDtoInfo> GetUserByIdAsync(int id)
    {
        var user = await userRepository.GetUserByIdAsync(id);
        return UserMapper.ToUserDtoInfo(user);
    }
    public async Task<UserDtoInfo> CreateUserAsync(UserDtoCreate userDtoCreate)
    {
        var user = await userRepository.CreateUserAsync(UserMapper.ToUser(userDtoCreate));
        return UserMapper.ToUserDtoInfo(user);
    }
    public async Task<UserDtoInfo> UpdateUserAsync(int id, UserDtoUpdate userDtoUpdate)
    {
        var existingUser = await userRepository.GetUserByIdAsync(id);
        existingUser.Name = userDtoUpdate.Name;
        var updatedUser = await userRepository.UpdateUserAsync(id, existingUser);
        return UserMapper.ToUserDtoInfo(updatedUser);
    }
    public async Task DeleteUserAsync(int id)
    {
        await userRepository.DeleteUserAsync(id);
    }
}
