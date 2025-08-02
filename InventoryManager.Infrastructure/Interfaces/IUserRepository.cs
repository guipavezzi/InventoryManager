public interface IUserRepository
{
    Task<User> Add(User entity);
    Task<bool> EmailExist(string email);
}