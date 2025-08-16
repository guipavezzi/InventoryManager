public interface ISaleRepository
{
    Task<Sale> Add(Sale entity);
}