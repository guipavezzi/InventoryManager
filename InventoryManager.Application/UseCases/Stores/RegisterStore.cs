using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Http;

public class RegisterStore
{
    private readonly IStoreRepository _storeRepository;
    private readonly IUserStoreRepository _userStoreRepository;
    private readonly IMapper _mapper;
    private readonly IHttpContextAccessor _httpContextAccessor;
    public RegisterStore(IStoreRepository storerepository,
                         IMapper mapper,
                         IUserStoreRepository userstorerepository,
                         IHttpContextAccessor httpContextAccessor)
    {
        _storeRepository = storerepository;
        _mapper = mapper;
        _userStoreRepository = userstorerepository;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<StoreRegisterResponse> Execute(RequestRegisterStore request)
    {
        var userIdClaim = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)
                         ?? _httpContextAccessor.HttpContext?.User?.FindFirst(JwtRegisteredClaimNames.Sub);

        if (userIdClaim is null)
            throw new UnauthorizedException("Usuário não autenticado!");

        if (await _storeRepository.StoreExist(request.Cnpj))
            throw new ConflictException("Loja já cadastrada");

        var store = await _storeRepository.Add(_mapper.Map<Store>(request));
        var userId = Guid.Parse(userIdClaim.Value);

        var userStore = new UserStore
        {
            UserId = userId,
            StoreId = store.Id,
        };

        await _userStoreRepository.Add(userStore);

        return new StoreRegisterResponse
        {
            Message = "Loja cadastrada com sucesso!"
        };
    }
}