public interface IStoreRepository
{
    Task<Store> Add(Store entity);
    Task<bool> StoreExist(string CNPJ);
    Task<bool> StoreExist(Guid id);
    Task<IList<Store>> GetStoresByIdUser(Guid userId);
}