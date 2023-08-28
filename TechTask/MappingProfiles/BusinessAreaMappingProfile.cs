using AutoMapper;
using TechTask.Models.Entities;
using TechTask.Models.ViewModels;

namespace TechTask.MappingProfiles;

public class BusinessAreaMappingProfile : Profile
{
    public BusinessAreaMappingProfile()
    {
        CreateMap<BusinessAreaViewModel.Area, BusinessArea>();
        CreateMap<BusinessAreaViewModel, BusinessArea>();
    }
}