using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

public class GetStores
{
    private readonly IStoreRepository _storeRepository;
    private readonly IHttpContextAccessor _httpContextAccessor;
    public GetStores(IStoreRepository storeRepository, IHttpContextAccessor httpContextAccessor)
    {
        _storeRepository = storeRepository;
        _httpContextAccessor = httpContextAccessor;
    }
    
    public async Task<IList<Store>> Execute()
    {
        var userIdClaim = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)
                         ?? _httpContextAccessor.HttpContext?.User?.FindFirst(JwtRegisteredClaimNames.Sub);

        if (userIdClaim is null)
            throw new UnauthorizedException("Usuário não autenticado!");

        var userId = Guid.Parse(userIdClaim.Value);
        var stores = await _storeRepository.GetStoresByIdUser(userId);

        if (stores is null)
            throw new NotFoundException("Nenhuma loja encontrada!");

        return stores;
    }
}