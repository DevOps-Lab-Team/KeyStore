using AutoMapper;
using KeyStore.Dto;
using KeyStore.Models;

namespace KeyStore.Helper;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Game, GameDto>().ReverseMap();
    }
}