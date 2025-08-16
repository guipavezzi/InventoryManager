public interface IProductSaleRepository
{
    Task<ProductSale> Add(ProductSale entity);
}