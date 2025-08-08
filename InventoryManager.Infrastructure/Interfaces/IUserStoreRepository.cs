public interface IUserStoreRepository
{
    Task<UserStore> Register(UserStore entity);
}