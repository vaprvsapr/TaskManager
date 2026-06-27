using Microsoft.EntityFrameworkCore;
using TaskManager.API.Models.Users;

namespace TaskManager.API.Data.Repositories;

public class UserRepository(AppDbContext dbContext)
{
    public async Task<IQueryable<User>> GetAllUsersAsync()
    {
        return dbContext.Users.Include(u => u.AssignedToTasks).Include(u => u.AssignedByTasks);
    }
    public async Task<User> GetUserByIdAsync(int id)
    {
        return await dbContext.Users.FindAsync(id) ?? 
            throw new KeyNotFoundException($"User with ID {id} not found.");
    }
    public async Task<User> CreateUserAsync(User user)
    {
        dbContext.Users.Add(user);
        await dbContext.SaveChangesAsync();
        return user;
    }
    public async Task<User> UpdateUserAsync(int id, User updatedUser)
    {
        var existingUser = await GetUserByIdAsync(id);
        existingUser.Name = updatedUser.Name;
        await dbContext.SaveChangesAsync();
        return existingUser;
    }
    public async Task DeleteUserAsync(int id)
    {
        var user = await GetUserByIdAsync(id);
        dbContext.Users.Remove(user);
        await dbContext.SaveChangesAsync();
    }
}