public interface IUserStoreRepository
{
    Task<UserStore> Add(UserStore entity);
}