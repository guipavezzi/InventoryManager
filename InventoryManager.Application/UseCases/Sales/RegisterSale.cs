using System.Threading.Tasks;
using AutoMapper;

public class RegisterSale
{
    private readonly ISaleRepository _saleRepository;
    private readonly IProductSaleRepository _productSaleRepository;
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public RegisterSale(ISaleRepository saleRepository,
                        IProductSaleRepository productSaleRepository,
                        IProductRepository productRepository,
                        IMapper mapper)
    {
        _saleRepository = saleRepository;
        _productSaleRepository = productSaleRepository;
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<SalesRegisterJson> Execute(IList<RequestProductsSale> products, Guid storeId)
    {
        var productsSale = GenerateProductSales(products);
        var sale = new Sale
        {
            DateSale = DateTime.UtcNow,
            StoreId = storeId,
            ProductSale = await productsSale
        };

        sale.TotalValue = sale.ProductSale.Sum(ps => ps.Amount * ps.Price);
        await _saleRepository.Add(sale);
        await UpdateProductAmount(await productsSale);

        return new SalesRegisterJson
        {
            Message = "Venda registrada com sucesso!"
        };
    }


    private async Task<List<ProductSale>> GenerateProductSales(IList<RequestProductsSale> products)
    {
        var productSales = new List<ProductSale>();

        foreach (var req in products)
        {
            var product = await _productRepository.GetById(req.Id);

            if (product is null)
                throw new NotFoundException("Produto não encontrado");

            productSales.Add(new ProductSale
            {
                ProductId = product.Id,
                Amount = req.Amount,
                Price = product.Price
            });
        }

        return productSales;
    }

    private async Task UpdateProductAmount(IList<ProductSale> productSales)
    {
        var ids = productSales.Select(ps => ps.ProductId).ToList();
        var products = await _productRepository.GetByIds(ids);

        foreach (var ps in productSales)
        {
            var product = products.First(p => p.Id == ps.ProductId);

            if (product.Amount < ps.Amount)
                throw new Exception($"Estoque insuficiente para o produto {product.Id}");

            product.Amount -= ps.Amount;
        }

        await _productRepository.Update(products);
    }
}