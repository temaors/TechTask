using AutoMapper;
using TechTask.Models;
using TechTask.Models.Entities;
using TechTask.Models.ViewModels;

namespace TechTask.MappingProfiles;

public class UserMappingProfile : Profile
{
    public UserMappingProfile()
    {
        CreateMap<PasswordViewModel, User>().ForMember(dest => dest.Password, opt => opt.MapFrom(src => $"{src.Pass}"));
        CreateMap<BusinessAreaViewModel, User>();
    }
}