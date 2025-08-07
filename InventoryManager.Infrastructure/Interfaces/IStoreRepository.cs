public interface IStoreRepository
{
    Task<Store> Add(Store entity);
    Task<bool> StoreExist(string CNPJ);
}