using AutoMapper;
using TechTask.Models;
using TechTask.Models.Entities;

namespace TechTask.MappingProfiles;

public class ContactInfoMappingProfile : Profile
{
    public ContactInfoMappingProfile()
    {
        CreateMap<ContactInfoViewModel, ContactInfo>();
    }
}