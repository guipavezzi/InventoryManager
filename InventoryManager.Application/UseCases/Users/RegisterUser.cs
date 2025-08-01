using System.Threading.Tasks;
using AutoMapper;

public class RegisterUser
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    public RegisterUser(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<UserRegisterResponse> Execute(RequestUserRegister request)
    {
        if (await _userRepository.EmailExist(request.Email))
            return new UserRegisterResponse{Response = "Email Já cadastraado"};
        
        var passwordCryptography = new PasswordHasher();
        var hashSalt = passwordCryptography.HashPassword(request.Password);

        var user = _mapper.Map<User>(request);
        user.Password = hashSalt.Hash;
        user.Salt = hashSalt.Salt;

        await _userRepository.Add(user);

        return new UserRegisterResponse{Response = "Usuário Cadastrado com Sucesso"};
    }
}