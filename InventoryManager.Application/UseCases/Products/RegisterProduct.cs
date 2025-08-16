using AutoMapper;

public class RegisterProduct
{
    private readonly IProductRepository _productRepository;
    private readonly IStoreRepository _storeRepository;
    private readonly IMapper _mapper;
    public RegisterProduct(IProductRepository productRepository, IMapper mapper, IStoreRepository storeRepository)
    {
        _productRepository = productRepository;
        _mapper = mapper;
        _storeRepository = storeRepository;
    }

    public async Task<ProductRegisterJson> Execute(RequestProductRegister request, Guid storeId)
    {
        if(!await _storeRepository.StoreExist(storeId))
            throw new NotFoundException("Loja não encontrada");

        request.StoreId = storeId;
        var product = await _productRepository.Add(_mapper.Map<Product>(request));

        if (product is null)
            throw new NotFoundException("Erro ao cadastrar produto");

        return new ProductRegisterJson
        {
            Message = "Produto Cadastrado com Sucesso!"
        };
    }
}