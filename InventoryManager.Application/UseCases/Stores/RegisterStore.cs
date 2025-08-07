using AutoMapper;

public class RegisterStore
{
    private readonly IStoreRepository _storeRepository;
    private readonly IMapper _mapper;
    public RegisterStore(IStoreRepository storerepository, IMapper mapper)
    {
        _storeRepository = storerepository;
        _mapper = mapper;
    }

    public async Task<StoreRegisterResponse> Execute(RequestRegisterStore request)
    {
        if (await _storeRepository.StoreExist(request.Cnpj))
            throw new ConflictException("Loja já cadastrada");

        await _storeRepository.Add(_mapper.Map<Store>(request));

        return new StoreRegisterResponse
        {
            Message = "Loja cadastrada com sucesso!"
        };
    }
}