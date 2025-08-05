public interface IUserRepository
{
    Task<User> Add(User entity);
    Task<bool> EmailExist(string email);
    Task<User> GetUser(string email);
}