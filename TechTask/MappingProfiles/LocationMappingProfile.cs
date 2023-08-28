using System.Net.Sockets;
using AutoMapper;
using TechTask.Models.Entities;

namespace TechTask.MappingProfiles;

public class LocationMappingProfile : Profile
{
    public LocationMappingProfile()
    {
        CreateMap<AddressViewModel, Location>()
            .ForMember(dest => dest.Address, opt => opt.MapFrom(src => $"{src.Location}"));
    }
}