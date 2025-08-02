
using Microsoft.EntityFrameworkCore;

public class UserRepository : IUserRepository
{
    private readonly ContextDB _context;

    public UserRepository(ContextDB context)
    {
        _context = context;
    }
    public async Task<User> Add(User entity)
    {
        await _context.Users.AddAsync(entity);
        await _context.SaveChangesAsync();

        return entity;
    }

    public async Task<bool> EmailExist(string email)
    {
        return await _context.Users.AnyAsync(u => u.Email.Equals(email));
    }
}