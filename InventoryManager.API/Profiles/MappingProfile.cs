using AutoMapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<RequestUserRegister, User>();
        CreateMap<RequestRegisterStore, Store>();
        CreateMap<RequestProductRegister, Product>();
    }
}